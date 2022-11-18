using Permaquim.Depositary.UI.Desktop.Helpers;
using System.Drawing;
using System.Drawing.Printing;
using System.Reflection.Metadata.Ecma335;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class ReportController
    {
        private const string TICKET = "TICKET: ";
        private const char LINE = '_';
        private const char STAR = '*';
        private const char SPACE = ' ';
        private static Image _image;
        private static Font _font;
        private static Font _boldFont;
        private static float _fontHeight;
        private static Rectangle _rectangle;
        private static int _headerTextStart_X;
        private static int _detailStart_X;
        private static int _interlineSpace;
        private static int _reportHeight;
        static dynamic _header;
        static dynamic _details;
        private static string _copyInstance = string.Empty;

        /// <summary>
        /// Representa el turno que esta en impresion en el reporte de turnos
        /// </summary>
        public static Depositario.Entities.Relations.Operacion.Turno TurnToPrint;

        /// <summary>
        /// Representa el contenedor que esta en impresion en el reporte de turnos
        /// </summary>
        public static Depositario.Entities.Relations.Operacion.Contenedor ContainerToPrint;

        public static Depositario.Entities.Relations.Operacion.CierreDiario DailyClosingToPrint;

        private static Depositario.Entities.Tables.Impresion.Ticket _ticket;

        private static string _fechaHora;

        private static string _code = String.Empty;

        private const int MAXCHARACTERLENGHT = 33;

        public static void PrintReport(ReportTypeEnum reportType,
            dynamic header, dynamic details, int copyIndex, string code = "")
        {
            try
            {
                _code = code;

                if (copyIndex == 0)
                    _copyInstance = MultilanguangeController.GetText(MultiLanguageEnum.IMPRESION_ORIGINAL);
                else
                    _copyInstance = MultilanguangeController.GetText(MultiLanguageEnum.IMPRESION_COPIA);

                if (header == null || details == null)
                {
                    FormsController.SetInformationMessage(InformationTypeEnum.Error, TICKET +
                        MultilanguangeController.GetText(MultiLanguageEnum.ERROR_DATO));
                    return;
                }

               _fechaHora = DateTime.Now.ToString(
                    MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA_HORA_COMPLETA));

                _header = header;
                _details = details;

                _ticket = DatabaseController.GetTicket(reportType);

                if (_ticket != null)
                {
                    try
                    {
                        string ps = PrinterController.GetCurrentPrinterstatus(_ticket.Impresora);
                        if (ps.Length > 0)
                            FormsController.SetInformationMessage(InformationTypeEnum.Alert, ps);
                    }
                    catch (Exception ex)
                    {
                        FormsController.SetInformationMessage(InformationTypeEnum.Error, ex.Message);
                        AuditController.Log(ex);
                    }

                        _image = ImageFromBase64Helper.GetImageFromBase64String(_ticket.Imagen);
                    _font = new Font(_ticket.NombreFuenteCabecera, _ticket.TamanioFuenteCabecera);
                    _boldFont = new Font(_font.Name, _font.Size, FontStyle.Bold);

                    _fontHeight = _font.Size * _font.FontFamily.GetCellAscent(FontStyle.Regular)
                           / _font.FontFamily.GetEmHeight(FontStyle.Regular);


                    _headerTextStart_X = Convert.ToInt32(_ticket.UbicacionTextoCabecera);

                    _rectangle = new Rectangle
                    {
                        X = Convert.ToInt32(_ticket.UbicacionImagen.Split(",")[0]),
                        Y = Convert.ToInt32(_ticket.UbicacionImagen.Split(",")[1]),
                        Width = Convert.ToInt32(_ticket.UbicacionImagen.Split(",")[2]),
                        Height = Convert.ToInt32(_ticket.UbicacionImagen.Split(",")[3])
                    };

                    _detailStart_X = Convert.ToInt32(_ticket.UbicacionTextoDetalle);

                    _interlineSpace = _ticket.TamanioEntreLineas;

                    _reportHeight = 0;


                    // Alto del reporte
                    _reportHeight += _rectangle.Y + _rectangle.Height; // Alto de la imágen
                    _reportHeight += (int)_fontHeight + _ticket.TamanioEntreLineas; // alto del texto de cabecera
                    _reportHeight += (int)_fontHeight + _ticket.TamanioEntreLineas; // alto del texto ORIGINAL / COPIA
                    _reportHeight += (int)_fontHeight + _ticket.TamanioEntreLineas; // alto del separador
                    _reportHeight += (_details.Count * 9) + (_ticket.TamanioEntreLineas * 6); // Alto del encabezado (usuario, codigo, etc.)
                    _reportHeight += (int)_fontHeight + _ticket.TamanioEntreLineas; // alto del separador
                    _reportHeight += (int)_fontHeight + _ticket.TamanioEntreLineas; // alto de titulos de columnas
                    _reportHeight += (int)_fontHeight; // alto del separador
                    _reportHeight += (_details.Count * _fontHeight) +
                        (_details.Count * _ticket.TamanioEntreLineas); // Alto del detalle
                    _reportHeight += (int)_fontHeight + _ticket.TamanioEntreLineas; // alto del separador
                    _reportHeight += (int)_fontHeight + _ticket.TamanioEntreLineas; // alto de total
                    _reportHeight += (int)_fontHeight + _ticket.TamanioEntreLineas; // alto del separador
                    _reportHeight += (int)_fontHeight + _ticket.TamanioEntreLineas; // alto del texto ORIGINAL / COPIA
                    _reportHeight += (int)_fontHeight + _ticket.TamanioEntreLineas; // alto del texto S:E:U:O
                    _reportHeight += ((int)_fontHeight * _ticket.LineasAlFinal) +
                        (_details.Count * _ticket.TamanioEntreLineas); // alto de las líneas al final

                    PrintDocument printDocument = new PrintDocument();

                    PaperSize paperSize = new PaperSize("Custom",
                    _ticket.AnchoReporte, _reportHeight);

                    paperSize.RawKind = (int)PaperKind.Custom;

                    printDocument.DefaultPageSettings.PaperSize = paperSize;

                    switch (reportType)
                    {
                        case ReportTypeEnum.None:
                            break;
                        case ReportTypeEnum.BillDeposit:
                            printDocument.PrintPage += PrintDocument_BillDepositPrintPage;
                            break;
                        case ReportTypeEnum.CoinDeposit:
                            break;
                        case ReportTypeEnum.EnvelopeDepositFirstReport:
                            printDocument.PrintPage += PrintDocument_EnvelopeDepositFirstReportPrintPage;
                            break;
                        case ReportTypeEnum.EnvelopeDepositSecondReport:
                            printDocument.PrintPage += PrintDocument_EnvelopeDepositSecondReportPrintPage;
                            break;
                        case ReportTypeEnum.ValueExtraction:
                            printDocument.PrintPage += PrintDocument_ValueExtractionPrintPage;
                            break;
                        case ReportTypeEnum.DailyClosing:
                            printDocument.PrintPage += PrintDocument_DailyclosingPrintPage;
                            break;
                        case ReportTypeEnum.TurnChange:
                            printDocument.PrintPage += PrintDocument_TurnChangePrintPage;
                            break;
                        default:
                            break;
                    }

                    printDocument.Print();

                }
                else
                {
                    FormsController.SetInformationMessage(InformationTypeEnum.Error,
                        MultilanguangeController.GetText(MultiLanguageEnum.TICKET_NO_CONFIGURADO));
                }

            }
            catch (Exception ex)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Error, ex.Message);
                AuditController.Log(ex);
            }

        }
 
        private static void PrintDocument_BillDepositPrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {


                decimal amount = 0;
                long itemsQuantity = 0;
                int yOffset;
                

                // dibuja el gráfico
                e.Graphics.DrawImage(_image, _rectangle);
                yOffset = _rectangle.Height + _interlineSpace;

                // Graba el texto de cabecera con el offset del alto del gráfico
                e.Graphics.DrawString(StringHelper.FormatString(_ticket.TextoCabecera,MAXCHARACTERLENGHT,StringHelper.AlignEnum.AlignMiddle), _font,
                Brushes.Black,
                _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Instancia (ORIGINAL / COPIA)
                e.Graphics.DrawString(_copyInstance, _boldFont,
                Brushes.Black,
                _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                    Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Referencia
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.TURNO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(((Permaquim.Depositario.Entities.Relations.Operacion.Transaccion)_header).TurnoId.TurnoDepositarioId.EsquemaDetalleTurnoId.Nombre, 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Transacción
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.CODIGO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(((Depositario.Entities.Relations.Operacion.Transaccion)_header).DepositarioId.CodigoExterno + "-" +
                ((Depositario.Entities.Relations.Operacion.Transaccion)_header).Fecha.ToString("yyMMdd") + "-" +
                ((Depositario.Entities.Relations.Operacion.Transaccion)_header).Id.ToString()
                , 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Usuario
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.USUARIO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(_header.UsuarioId.NombreApellido, 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Sucursal
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.SUCURSAL) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(_header.DepositarioId.SectorId.SucursalId.Nombre, 20, StringHelper.AlignEnum.AlignLeft)
                 , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Terminal
                e.Graphics.DrawString(
                                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.DEPOSITARIO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(_header.DepositarioId.CodigoExterno, 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Cuenta
                if (ParameterController.UsesBankAccount && _header.CuentaId != null)
                {
                    e.Graphics.DrawString(
                                        StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.CUENTA_BANCARIA) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                        StringHelper.FormatString(_header.CuentaId.Numero, 20, StringHelper.AlignEnum.AlignLeft)
                        , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                    yOffset += _interlineSpace;
                }

                // Origen
                if (ParameterController.UsesValueOrigin && _header.OrigenValorId != null)
                {
                    e.Graphics.DrawString(
                                        StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.ORIGEN_VALOR) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                        StringHelper.FormatString(_header.OrigenValorId.Nombre, 20, StringHelper.AlignEnum.AlignLeft)
                        , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                    yOffset += _interlineSpace;
                }

                // Fecha operacion
                var fechaOperacion = _header.
                        Fecha == null ? "" : ((DateTime)_header.
                        Fecha).ToString(MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA_HORA_COMPLETA));

                e.Graphics.DrawString(
                    StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.FECHA) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                    StringHelper.FormatString(fechaOperacion, 20, StringHelper.AlignEnum.AlignLeft)
                    , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                    Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                e.Graphics.DrawString(
                    //"DENOMINACION CANTIDAD TOTAL"
                    StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.MONEDA).Substring(0, 3), 4, StringHelper.AlignEnum.AlignLeft) +
                    StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.DENOMINACION).Substring(0, 3), 5, StringHelper.AlignEnum.AlignRight) +
                    StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.CANTIDAD).Substring(0, 4), 7, StringHelper.AlignEnum.AlignRight) +
                    StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.TOTAL), 16, StringHelper.AlignEnum.AlignRight)
                    , _font, Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                    Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;


                for (int i = 0; i < _details.Count; i++)
                {
                    var total = (_details[i].CantidadUnidades * _details[i].Unidades).ToString();

                    var data =

                    StringHelper.FormatString(_details[i].MonedaCodigo, 4, StringHelper.AlignEnum.AlignLeft) +
                    StringHelper.FormatString(_details[i].DenominacionNombre, 5, StringHelper.AlignEnum.AlignRight) +
                    StringHelper.FormatString(_details[i].CantidadUnidades.ToString(), 7, StringHelper.AlignEnum.AlignRight) +
                    StringHelper.FormatString(total, 17, StringHelper.AlignEnum.AlignRight);

                    e.Graphics.DrawString(data, _font, Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                    amount += _details[i].CantidadUnidades * _details[i].Unidades;
                    itemsQuantity += _details[i].CantidadUnidades;

                    yOffset += _interlineSpace;
                }

                yOffset += _interlineSpace;

                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                    Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Total

                var totalAmount = StringHelper.FormatString("Total " +
                    ((Depositario.Entities.Relations.Operacion.Transaccion)_header).MonedaId.Codigo + ":"
                    , 12, StringHelper.AlignEnum.AlignLeft) +
                    StringHelper.FormatString(amount.ToString(), 21, StringHelper.AlignEnum.AlignRight);

                e.Graphics.DrawString(totalAmount, _boldFont,
                    Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                    Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Instancia (ORIGINAL / COPIA)
                e.Graphics.DrawString(_copyInstance, _boldFont,
                Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                //Pie
                e.Graphics.DrawString(DateTime.Now.ToString(_fechaHora) + " " + _ticket.TextoPie,
                    _font, Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                for (int i = 0; i < _ticket.LineasAlFinal; i++)
                {
                    e.Graphics.DrawString(new String(' ', _ticket.AnchoDetalle), _boldFont,
                        Brushes.Black, _detailStart_X, yOffset, new StringFormat());
                    yOffset += _interlineSpace;
                }
                yOffset += _interlineSpace;

                // Separador
                e.Graphics.DrawString(new String(STAR, MAXCHARACTERLENGHT), _boldFont,
                    Brushes.Black, _detailStart_X, yOffset, new StringFormat());
            }
            catch (Exception ex)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Error, ex.Message);
                AuditController.Log(ex);
            }

        }

        private static void PrintDocument_EnvelopeDepositFirstReportPrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {

                int yOffset = 0;
                

                // dibuja el gráfico
                e.Graphics.DrawImage(_image, _rectangle);
                yOffset = _rectangle.Height + _interlineSpace;

                // Graba el texto de cabecera con el offset del alto del gráfico
                e.Graphics.DrawString(StringHelper.FormatString(_ticket.TextoCabecera,MAXCHARACTERLENGHT,StringHelper.AlignEnum.AlignMiddle), _font,
                Brushes.Black,
                _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Instancia (ORIGINAL / COPIA)
                e.Graphics.DrawString(_copyInstance, _boldFont,
                Brushes.Black,
                _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                           Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Referencia
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.TURNO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(DatabaseController.CurrentTurn.TurnoDepositarioId.EsquemaDetalleTurnoId.Nombre, 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                //// Transacción
                //e.Graphics.DrawString(
                //StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.CODIGO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                //StringHelper.FormatString(((Depositario.Entities.Relations.Operacion.Transaccion)_header).DepositarioId.CodigoExterno + "-" +
                //((Depositario.Entities.Relations.Operacion.Transaccion)_header).Fecha.ToString("yyMMdd") + "-" +
                //((Depositario.Entities.Relations.Operacion.Transaccion)_header).Id.ToString()
                //, 20, StringHelper.AlignEnum.AlignLeft)
                //, _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                //yOffset += _interlineSpace;

                var currentDepositary = DatabaseController.GetDepositary(_header.DepositarioId);

                // Usuario
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.USUARIO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(DatabaseController.CurrentUser.NombreApellido, 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Sucursal
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.SUCURSAL) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(currentDepositary.SectorId.SucursalId.Nombre, 20, StringHelper.AlignEnum.AlignLeft)
                 , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Terminal
                e.Graphics.DrawString(
                                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.DEPOSITARIO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(currentDepositary.CodigoExterno, 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                  
                yOffset += _interlineSpace;

                // Cuenta bancaria
                if (ParameterController.UsesBankAccount && _header.CuentaId != null)
                {
                    var currentBankAccount = DatabaseController.GetBankAccount(_header.CuentaId);

                    e.Graphics.DrawString(
                                        StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.CUENTA_BANCARIA) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                        StringHelper.FormatString(currentBankAccount.Numero, 20, StringHelper.AlignEnum.AlignLeft)
                        , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                    yOffset += _interlineSpace;
                }
                // Origen del depósito
                if (ParameterController.UsesValueOrigin && _header.OrigenValorId != null)
                {
                    var currentValueOrigin = DatabaseController.GetValueOrigin(_header.OrigenValorId);
                    e.Graphics.DrawString(
                                        StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.ORIGEN_VALOR) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                        StringHelper.FormatString(currentValueOrigin.Nombre, 20, StringHelper.AlignEnum.AlignLeft)
                        , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                    yOffset += _interlineSpace;
                }

                // Fecha operacion
                var fechaOperacion = _header.
                        Fecha == null ? "" : ((DateTime)_header.
                        Fecha).ToString(MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA_HORA_COMPLETA) );
                
                e.Graphics.DrawString(
                    StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.FECHA) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                    StringHelper.FormatString(fechaOperacion, 20, StringHelper.AlignEnum.AlignLeft)
                    , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;
                yOffset += _interlineSpace;

                // Contenido del sobre
                e.Graphics.DrawString(
                    MultilanguangeController.GetText(MultiLanguageEnum.CONTENIDO_DEL_SOBRE) + ": " +
                    _code
                    , _font,Brushes.Black,_detailStart_X, yOffset, new StringFormat());


                // Separador +
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                            Brushes.Black,
                            _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;
                yOffset += _interlineSpace;

                foreach (var item in _details)
                   {


                    e.Graphics.DrawString(
                        StringHelper.FormatString(
                         DatabaseController.GetCurrencyValueRelation(item.RelacionMonedaTipoValorId).TipoValorId.Nombre + SPACE +
                         DatabaseController.GetCurrencyValueRelation(item.RelacionMonedaTipoValorId).MonedaId.Codigo, 15, StringHelper.AlignEnum.AlignLeft) +
                         StringHelper.FormatString(
                         item.CantidadDeclarada.ToString(), 18, StringHelper.AlignEnum.AlignRight)
                         , _font, Brushes.Black, _detailStart_X, yOffset, new StringFormat());
     
                    yOffset += _interlineSpace;
                }
                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                        Brushes.Black,
                        _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;


                yOffset += _interlineSpace;

 
                // Instancia (ORIGINAL / COPIA)
                e.Graphics.DrawString(_copyInstance, _boldFont,
                Brushes.Black,
                _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                //Pie
                e.Graphics.DrawString(DateTime.Now.ToString(_fechaHora) + SPACE + _ticket.TextoPie,
                    _font, Brushes.Black,
                _detailStart_X, yOffset, new StringFormat());

                // Separador
                e.Graphics.DrawString(new String(STAR, MAXCHARACTERLENGHT), _boldFont,
                            Brushes.Black,
                            _detailStart_X, yOffset, new StringFormat());

                for (int i = 0; i < _ticket.LineasAlFinal; i++)
                {
                    e.Graphics.DrawString(new String(' ', _ticket.AnchoDetalle), _boldFont,
                        Brushes.Black,
                        _detailStart_X, yOffset, new StringFormat());
                    yOffset += _interlineSpace;
                }
                yOffset += _interlineSpace;

            }
            catch (Exception ex)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Error, ex.Message);
                AuditController.Log(ex);
            }
        }

        private static void PrintDocument_EnvelopeDepositSecondReportPrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {

                int yOffset;
                

                // dibuja el gráfico
                e.Graphics.DrawImage(_image, _rectangle);
                yOffset = _rectangle.Height + _interlineSpace;

                // Graba el texto de cabecera con el offset del alto del gráfico
                e.Graphics.DrawString(StringHelper.FormatString(_ticket.TextoCabecera,MAXCHARACTERLENGHT,StringHelper.AlignEnum.AlignMiddle), _font,
                Brushes.Black,
                _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Instancia (ORIGINAL / COPIA)
                e.Graphics.DrawString(_copyInstance, _boldFont,
                Brushes.Black,
                _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                           Brushes.Black,
                           _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Referencia
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.TURNO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(DatabaseController.CurrentTurn.TurnoDepositarioId.EsquemaDetalleTurnoId.Nombre, 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Transacción
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.CODIGO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(((Depositario.Entities.Relations.Operacion.Transaccion)_header).DepositarioId.CodigoExterno + "-" +
                ((Depositario.Entities.Relations.Operacion.Transaccion)_header).Fecha.ToString("yyMMdd") + "-" +
                ((Depositario.Entities.Relations.Operacion.Transaccion)_header).Id.ToString()
                , 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Usuario
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.USUARIO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(_header.UsuarioId.NombreApellido, 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Sucursal
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.SUCURSAL) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(_header.DepositarioId.SectorId.SucursalId.Nombre, 20, StringHelper.AlignEnum.AlignLeft)
                 , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Terminal
                e.Graphics.DrawString(
                                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.DEPOSITARIO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(_header.DepositarioId.CodigoExterno, 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                //Cuenta bancaria
                if (ParameterController.UsesBankAccount && _header.CuentaId != null)
                {
                    e.Graphics.DrawString(
                                        StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.CUENTA_BANCARIA) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                        StringHelper.FormatString(_header.CuentaId.Numero, 20, StringHelper.AlignEnum.AlignLeft)
                        , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                    yOffset += _interlineSpace;
                }

                // Origen del depósito
                if (ParameterController.UsesValueOrigin && _header.OrigenValorId != null)
                {
                    e.Graphics.DrawString(
                                        StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.ORIGEN_VALOR) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                        StringHelper.FormatString(_header.OrigenValorId.Nombre, 20, StringHelper.AlignEnum.AlignLeft)
                        , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                    yOffset += _interlineSpace;
                }

                // Fecha operacion
                var fechaOperacion = _header.
                        Fecha == null ? "" : ((DateTime)_header.
                        Fecha).ToString(MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA_HORA_COMPLETA));

                e.Graphics.DrawString(
                    StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.FECHA) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                    StringHelper.FormatString(fechaOperacion, 20, StringHelper.AlignEnum.AlignLeft)
                    , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;
                yOffset += _interlineSpace;

                // Contenido del sobre
                e.Graphics.DrawString(
                    MultilanguangeController.GetText(MultiLanguageEnum.CONTENIDO_DEL_SOBRE) + ": " +
                    (((Permaquim.Depositario.Entities.Relations.Operacion.Transaccion)_header)
                          .ListOf_TransaccionSobre_TransaccionId)[0].CodigoSobre
                    , _font,Brushes.Black,_detailStart_X, yOffset, new StringFormat());


                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                            Brushes.Black,
                            _detailStart_X, yOffset, new StringFormat());

                 yOffset += _interlineSpace;
                yOffset += _interlineSpace;

                foreach (var item in (((Permaquim.Depositario.Entities.Relations.Operacion.Transaccion)_header)
                    .ListOf_TransaccionSobre_TransaccionId)[0].ListOf_TransaccionSobreDetalle_SobreId)
                {
                    e.Graphics.DrawString(
                         StringHelper.FormatString(
                         item.RelacionMonedaTipoValorId.TipoValorId.Nombre + SPACE +
                         item.RelacionMonedaTipoValorId.MonedaId.Codigo,15,StringHelper.AlignEnum.AlignLeft) +
                         StringHelper.FormatString(
                         item.CantidadDeclarada.ToString(),18,StringHelper.AlignEnum.AlignRight)
                         , _font,Brushes.Black,_detailStart_X, yOffset, new StringFormat());

                    yOffset += _interlineSpace;
                }
                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                        Brushes.Black,
                        _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                yOffset += _interlineSpace;

                // Instancia (ORIGINAL / COPIA)
                e.Graphics.DrawString(_copyInstance, _boldFont,
                Brushes.Black,
                _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                //Pie
                e.Graphics.DrawString(DateTime.Now.ToString(_fechaHora) + SPACE + _ticket.TextoPie,
                    _font, Brushes.Black,
                _detailStart_X, yOffset, new StringFormat());

                for (int i = 0; i < _ticket.LineasAlFinal; i++)
                {
                    e.Graphics.DrawString(new String(' ', _ticket.AnchoDetalle), _boldFont,
                        Brushes.Black,
                        _detailStart_X, yOffset, new StringFormat());
                    yOffset += _interlineSpace;
                }

                yOffset += _interlineSpace;
                // Separador
                e.Graphics.DrawString(new String(STAR, MAXCHARACTERLENGHT), _boldFont,
                            Brushes.Black,
                            _detailStart_X, yOffset, new StringFormat());
            }
            catch (Exception ex)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Error, ex.Message);
                AuditController.Log(ex);
            }

        }

        private static void PrintDocument_ValueExtractionPrintPage(object sender, PrintPageEventArgs e)
        {

            decimal amount = 0;
            int yOffset;
            

            try
            {

                // dibuja el gráfico
                e.Graphics.DrawImage(_image, _rectangle);
                yOffset = _rectangle.Height + _interlineSpace;

                // Graba el texto de cabecera con el offset del alto del gráfico
                e.Graphics.DrawString(StringHelper.FormatString(_ticket.TextoCabecera,MAXCHARACTERLENGHT,StringHelper.AlignEnum.AlignMiddle), _font,
                Brushes.Black,
                _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Instancia (ORIGINAL / COPIA)
                e.Graphics.DrawString(_copyInstance, _boldFont,
                Brushes.Black,
                _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                           Brushes.Black,
                           _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                //Obtenemos la transaccion con la que se hizo el retiro de bolsa.
                var bagExtractionTransaction = ContainerToPrint.ListOf_Transaccion_ContenedorId.FirstOrDefault(x => x._TipoId == (Int64)OperationTypeEnum.ValueExtraction);
                
                string turnName;

                if(bagExtractionTransaction != null)
                    turnName = bagExtractionTransaction.TurnoId.TurnoDepositarioId.EsquemaDetalleTurnoId.Nombre;
                else
                    turnName = MultilanguangeController.GetText(MultiLanguageEnum.SIN_TURNO).Substring(0, 18);

                // Referencia
                e.Graphics.DrawString(
                 StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.TURNO) + ": ", 16, StringHelper.AlignEnum.AlignLeft) +
                 StringHelper.FormatString(turnName, 20, StringHelper.AlignEnum.AlignLeft)
                 , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                if (DatabaseController.CurrentUser != null )
                {
                    // Usuario
                    e.Graphics.DrawString(
                    StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.USUARIO) + ": ", 16, StringHelper.AlignEnum.AlignLeft) +
                    StringHelper.FormatString(ContainerToPrint.UsuarioModificacion.NombreApellido, 20, StringHelper.AlignEnum.AlignLeft)
                    , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                    yOffset += _interlineSpace;
                }
                else
                {
                    // Usuario no registrado
                    e.Graphics.DrawString(
                      StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.USUARIO) + ": ", 16, StringHelper.AlignEnum.AlignLeft) +
                      StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.SIN_USUARIO), 20, StringHelper.AlignEnum.AlignLeft)
                      , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                    yOffset += _interlineSpace;
                }

                // Sucursal
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.SUCURSAL) + ": ", 16, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(ContainerToPrint.DepositarioId.SectorId.SucursalId.Nombre, 20, StringHelper.AlignEnum.AlignLeft)
                 , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Terminal
                e.Graphics.DrawString(
                                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.DEPOSITARIO) + ": ", 16, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(ContainerToPrint.DepositarioId.CodigoExterno, 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Contenedor
                e.Graphics.DrawString(
                                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.CONTENEDOR) + ": ", 16, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(ContainerToPrint.Nombre, 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                string fechaaperura = 
                    ContainerToPrint.FechaApertura.ToString(MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA_HORA_COMPLETA));

                // Fecha Apertura
                e.Graphics.DrawString(
                    StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.FECHA_APERTURA) + ": ", 16, StringHelper.AlignEnum.AlignLeft) +
                    StringHelper.FormatString(fechaaperura, 20, StringHelper.AlignEnum.AlignLeft)
                    , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Fecha Cierre
                var fechaCierre = ContainerToPrint.FechaCierre == null ? "" :
                    ((DateTime)ContainerToPrint.FechaCierre).ToString(MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA_HORA_COMPLETA));


                e.Graphics.DrawString(
                    StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.FECHA_CIERRE) + ": ", 16, StringHelper.AlignEnum.AlignLeft) +
                    StringHelper.FormatString(fechaCierre, 20, StringHelper.AlignEnum.AlignLeft)
                    , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                            Brushes.Black,
                            _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;


                if (_details.Count > 0)
                {

                    List<string> currencies = new();

                    foreach (var item in _details)
                    {
                        if (!currencies.Contains(item.Moneda))
                        {
                            currencies.Add(item.Moneda);

                        }
                    }
                    string currentCurrency = string.Empty;

                    foreach (var currency in currencies)
                    {
                        yOffset += _interlineSpace;

                        if (!currentCurrency.Equals(currency))
                        {
                            amount = 0;
                            currentCurrency = currency;
                        }

                        // Billetes
                        e.Graphics.DrawString(MultilanguangeController.GetText(MultiLanguageEnum.BILLETE) + " " + currency + ": ", _boldFont,
                            Brushes.Black,
                            _detailStart_X, yOffset, new StringFormat());

                        yOffset += _interlineSpace;


                        e.Graphics.DrawString(
                         //"MONEDA DENOMINACION CANTIDAD TOTAL"
                         StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.MONEDA).Substring(0, 3), 5, StringHelper.AlignEnum.AlignLeft) +
                         StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.DENOMINACION).Substring(0, 5), 5, StringHelper.AlignEnum.AlignLeft) +
                         StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.CANTIDAD).Substring(0, 4), 6, StringHelper.AlignEnum.AlignRight) +
                         StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.TOTAL), 17, StringHelper.AlignEnum.AlignRight)
                         , _font, Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                        // Separador
                        e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                                    Brushes.Black,
                                    _detailStart_X, yOffset, new StringFormat());

                        yOffset += _interlineSpace;


                        foreach (var item in _details)
                        {


                            if (item.Cantidad > 0 && item.Moneda.Equals(currentCurrency))
                            {
                                var partialAmount = item.Cantidad * Convert.ToInt64(item.Denominacion);
                                amount += item.Cantidad * Convert.ToInt64(item.Denominacion);

                                var data =
                                StringHelper.FormatString(item.Moneda, 4, StringHelper.AlignEnum.AlignLeft) +
                                StringHelper.FormatString(item.Denominacion, 5, StringHelper.AlignEnum.AlignRight) +
                                StringHelper.FormatString(item.Cantidad.ToString(), 7, StringHelper.AlignEnum.AlignRight) +
                                StringHelper.FormatString(partialAmount.ToString(), 17, StringHelper.AlignEnum.AlignRight);

                                e.Graphics.DrawString(data, _font, Brushes.Black, _detailStart_X, yOffset, new StringFormat());


                                yOffset += _interlineSpace;
                            }
                        }
                        yOffset += _interlineSpace;

                        // Separador
                        e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                                Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                        yOffset += _interlineSpace;

                        // Total
                        var totalAmount = StringHelper.FormatString("Total " + currency + ": " , 13, StringHelper.AlignEnum.AlignLeft) +
                            StringHelper.FormatString(amount.ToString(), 20, StringHelper.AlignEnum.AlignRight);

                        e.Graphics.DrawString(totalAmount, _boldFont,
                            Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                        yOffset += _interlineSpace;

                    }

                }
                if (_header.Count > 0)
                {
                    // Separador
                    e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                            Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                    yOffset += _interlineSpace;
                    // sobres
                    e.Graphics.DrawString(MultilanguangeController.GetText(MultiLanguageEnum.SOBRE) + ": ", _boldFont,
                                Brushes.Black,
                                _detailStart_X, yOffset, new StringFormat());

                    yOffset += _interlineSpace;

                    // Separador
                    e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                                Brushes.Black,
                                _detailStart_X, yOffset, new StringFormat());

                    e.Graphics.DrawString(
                     //"MONEDA DENOMINACION CANTIDAD"
                     StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.MONEDA), 10, StringHelper.AlignEnum.AlignLeft) +
                     StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.DENOMINACION).Substring(0, 8) + ".", 10, StringHelper.AlignEnum.AlignLeft) +
                     StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.CANTIDAD), 13, StringHelper.AlignEnum.AlignRight)

                     , _font, Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                    yOffset += _interlineSpace;
                    string currencyValueRelation = string.Empty;

                    foreach (var item in _header)
                    {

                        var data =
                            StringHelper.FormatString(((Permaquim.Depositary.UI.Desktop.Entities.BagContentItem)item).Moneda.Substring(0, 8) + ".", 10, StringHelper.AlignEnum.AlignLeft) +
                            StringHelper.FormatString(((Permaquim.Depositary.UI.Desktop.Entities.BagContentItem)item).Denominacion, 10, StringHelper.AlignEnum.AlignLeft) +
                            StringHelper.FormatString(((Permaquim.Depositary.UI.Desktop.Entities.BagContentItem)item).Cantidad.ToString(), 13, StringHelper.AlignEnum.AlignRight);

                        e.Graphics.DrawString(data, _font, Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                        yOffset += _interlineSpace;
                    }
                }

                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                            Brushes.Black,
                            _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Instancia (ORIGINAL / COPIA)
                e.Graphics.DrawString(_copyInstance, _boldFont,
                Brushes.Black,
                _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                //Pie
                e.Graphics.DrawString(DateTime.Now.ToString(_fechaHora) + SPACE + _ticket.TextoPie,
                    _font, Brushes.Black,
                _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;
                // Separador
                e.Graphics.DrawString(new String(STAR, MAXCHARACTERLENGHT), _boldFont,
                            Brushes.Black,
                            _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                for (int i = 0; i < _ticket.LineasAlFinal; i++)
                {
                    e.Graphics.DrawString(new String(' ', _ticket.AnchoDetalle), _boldFont,
                        Brushes.Black,
                        _detailStart_X, yOffset, new StringFormat());
                    yOffset += _interlineSpace;
                }

                yOffset += _interlineSpace;
      
            }
            catch (Exception ex)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Error, ex.Message);
                AuditController.Log(ex);
            }
        }

        private static void PrintDocument_DailyclosingPrintPage(object sender, PrintPageEventArgs e)
        {

            try
            {

                decimal amount = 0;
                int yOffset;
                

                // dibuja el gráfico
                e.Graphics.DrawImage(_image, _rectangle);
                yOffset = _rectangle.Height + _interlineSpace;

                // Graba el texto de cabecera con el offset del alto del gráfico
                e.Graphics.DrawString(StringHelper.FormatString(_ticket.TextoCabecera,MAXCHARACTERLENGHT,StringHelper.AlignEnum.AlignMiddle), _font,
                Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Instancia (ORIGINAL / COPIA)
                e.Graphics.DrawString(_copyInstance, _boldFont,
                Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                    Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Referencia
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.CIERREDIARIO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(DailyClosingToPrint.CodigoCierre, 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Usuario
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.USUARIO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(DailyClosingToPrint.UsuarioCreacion.NombreApellido, 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Sucursal
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.SUCURSAL) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(DatabaseController.CurrentDepositary.SectorId.SucursalId.Nombre, 20, StringHelper.AlignEnum.AlignLeft)
                 , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Terminal
                e.Graphics.DrawString(
                                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.DEPOSITARIO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(DatabaseController.CurrentDepositary.CodigoExterno, 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Fecha operacion
                var fechaCierre = DailyClosingToPrint.
                        Fecha == null ? "" : ((DateTime)DailyClosingToPrint.
                        Fecha).ToString(MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA_HORA_COMPLETA));

                e.Graphics.DrawString(
                    StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.FECHA_CIERRE) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                    StringHelper.FormatString(fechaCierre, 20, StringHelper.AlignEnum.AlignLeft)
                    , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                            Brushes.Black,
                            _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;
                if (_details.Count > 0)
                {
                    List<string> currencies = new();

                    foreach (var item in _details)
                    {
                        if (!currencies.Contains(item.Moneda))
                        {
                            if (item.Cantidad > 0)
                                currencies.Add(item.Moneda);

                        }
                    }
                    string currentCurrency = string.Empty;

                    foreach (var currency in currencies)
                    {
                        yOffset += _interlineSpace;

                        if (!currentCurrency.Equals(currency))
                        {
                            amount = 0;
                            currentCurrency = currency;
                        }
                        // Billetes
                        e.Graphics.DrawString(MultilanguangeController.GetText(MultiLanguageEnum.BILLETE) + " " + currentCurrency + ": ", _boldFont,
                        Brushes.Black,
                        _detailStart_X, yOffset, new StringFormat());

                        yOffset += _interlineSpace;

                        e.Graphics.DrawString(
                         //"DENOMINACION CANTIDAD TOTAL"
                         StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.DENOMINACION).Substring(0, 5), 5, StringHelper.AlignEnum.AlignLeft) +
                         StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.CANTIDAD).Substring(0, 4), 10, StringHelper.AlignEnum.AlignRight) +
                         StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.TOTAL), 17, StringHelper.AlignEnum.AlignRight)
                         , _font, Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                        // Separador
                        e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                                    Brushes.Black,
                                    _detailStart_X, yOffset, new StringFormat());

                        yOffset += _interlineSpace;

                        foreach (var item in _details)
                        {

                            if (item.Cantidad > 0 && item.Moneda.Equals(currentCurrency))
                            {
                                var partialAmount = item.Cantidad * item.UnidadesDenominacion;
                                amount += item.Cantidad * item.UnidadesDenominacion;

                                var data =
                                StringHelper.FormatString(item.Moneda, 4, StringHelper.AlignEnum.AlignLeft) +
                                StringHelper.FormatString(item.Denominacion, 5, StringHelper.AlignEnum.AlignRight) +
                                StringHelper.FormatString(item.Cantidad.ToString(), 7, StringHelper.AlignEnum.AlignRight) +
                                StringHelper.FormatString(partialAmount.ToString(), 17, StringHelper.AlignEnum.AlignRight);

                                e.Graphics.DrawString(data, _font, Brushes.Black, _detailStart_X, yOffset, new StringFormat());


                                yOffset += _interlineSpace;
                            }
                        }

                        // Separador
                        e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                                Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                        yOffset += _interlineSpace;

                        // Total
                         var totalAmount = StringHelper.FormatString("Total " + currency + ": ", 13, StringHelper.AlignEnum.AlignLeft) +
                            StringHelper.FormatString(amount.ToString(), 20, StringHelper.AlignEnum.AlignRight);

                        e.Graphics.DrawString(totalAmount, _boldFont,
                            Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                        yOffset += _interlineSpace;



                    }
                }
                if (_header.Count > 0)
                {
                    // Separador
                    e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                            Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                    yOffset += _interlineSpace;
                    // sobres
                    e.Graphics.DrawString(MultilanguangeController.GetText(MultiLanguageEnum.SOBRE) + ": ", _boldFont,
                                Brushes.Black,
                                _detailStart_X, yOffset, new StringFormat());

                    yOffset += _interlineSpace;

                    // Separador
                    e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                                Brushes.Black,
                                _detailStart_X, yOffset, new StringFormat());

                    e.Graphics.DrawString(
                     //"MONEDA DENOMINACION CANTIDAD"
                     StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.MONEDA), 10, StringHelper.AlignEnum.AlignLeft) +
                     StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.DENOMINACION).Substring(0, 8) + ".", 10, StringHelper.AlignEnum.AlignLeft) +
                     StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.CANTIDAD), 13, StringHelper.AlignEnum.AlignRight)

                     , _font, Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                    yOffset += _interlineSpace;


                    foreach (var item in _header)
                    {
                        var data =
                            StringHelper.FormatString(((Permaquim.Depositary.UI.Desktop.Entities.BagContentItem)item).Moneda.Substring(0, 8) + ".", 10, StringHelper.AlignEnum.AlignLeft) +
                            StringHelper.FormatString(((Permaquim.Depositary.UI.Desktop.Entities.BagContentItem)item).Denominacion, 10, StringHelper.AlignEnum.AlignLeft) +
                            StringHelper.FormatString(((Permaquim.Depositary.UI.Desktop.Entities.BagContentItem)item).Cantidad.ToString(), 13, StringHelper.AlignEnum.AlignRight);

                        e.Graphics.DrawString(data, _font, Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                        yOffset += _interlineSpace;
                    }


                    // Separador
                    e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                                Brushes.Black,
                                _detailStart_X, yOffset, new StringFormat());

                }

                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                        Brushes.Black,
                        _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Total

                 var totalAmount2 = StringHelper.FormatString("Total: ", 7, StringHelper.AlignEnum.AlignLeft) +
                    StringHelper.FormatString(amount.ToString(), 26, StringHelper.AlignEnum.AlignRight);

                yOffset += _interlineSpace;

                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                         Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Instancia (ORIGINAL / COPIA)
                e.Graphics.DrawString(_copyInstance, _boldFont,
                Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                //Pie
                e.Graphics.DrawString(DateTime.Now.ToString(_fechaHora) + SPACE + _ticket.TextoPie,
                    _font, Brushes.Black,
                _detailStart_X, yOffset, new StringFormat());

                for (int i = 0; i < _ticket.LineasAlFinal; i++)
                {
                    e.Graphics.DrawString(new String(' ', _ticket.AnchoDetalle), _boldFont,
                        Brushes.Black,
                        _detailStart_X, yOffset, new StringFormat());
                    yOffset += _interlineSpace;
                }
                yOffset += _interlineSpace;
                // Separador
                e.Graphics.DrawString(new String(STAR, MAXCHARACTERLENGHT), _boldFont,
                            Brushes.Black,
                            _detailStart_X, yOffset, new StringFormat());
            }
            catch (Exception ex)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Error, ex.Message);
                AuditController.Log(ex);
            }
        }

        private static void PrintDocument_TurnChangePrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {

                decimal amount = 0;
                int yOffset;
                


                // dibuja el gráfico
                e.Graphics.DrawImage(_image, _rectangle);
                yOffset = _rectangle.Height + _interlineSpace;

                // Graba el texto de cabecera con el offset del alto del gráfico
                e.Graphics.DrawString(StringHelper.FormatString(_ticket.TextoCabecera,MAXCHARACTERLENGHT,StringHelper.AlignEnum.AlignMiddle), _font,
                Brushes.Black,
                _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Instancia (ORIGINAL / COPIA)
                e.Graphics.DrawString(_copyInstance, _boldFont,
                Brushes.Black,
                _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                           Brushes.Black,
                           _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Referencia
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.TURNO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(ReportController.TurnToPrint.TurnoDepositarioId.EsquemaDetalleTurnoId.Nombre, 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Transacción
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.CODIGO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(ReportController.TurnToPrint.CodigoTurno + "-" +
                ReportController.TurnToPrint.Id.ToString()
                , 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Usuario
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.USUARIO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(ReportController.TurnToPrint.UsuarioCreacion.NombreApellido, 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Sucursal
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.SUCURSAL) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(ReportController.TurnToPrint.DepositarioId.SectorId.SucursalId.Nombre, 20, StringHelper.AlignEnum.AlignLeft)
                 , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                // Terminal
                e.Graphics.DrawString(
                StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.DEPOSITARIO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                StringHelper.FormatString(ReportController.TurnToPrint.DepositarioId.CodigoExterno, 20, StringHelper.AlignEnum.AlignLeft)
                , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Fecha turno
                var fechaTurno = ReportController.TurnToPrint.
                        Fecha == null ? "" : ((DateTime)ReportController.TurnToPrint.
                        Fecha).ToString(MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA));

                e.Graphics.DrawString(
                    StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.FECHA_TURNO) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                    StringHelper.FormatString(fechaTurno, 20, StringHelper.AlignEnum.AlignLeft)
                    , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Fecha apertura
                var fechaApertura = ReportController.TurnToPrint.
                        FechaApertura == null ? "" : ((DateTime)ReportController.TurnToPrint.
                        FechaApertura).ToString(MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA_HORA_COMPLETA) );

                e.Graphics.DrawString(
                    StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.FECHA_APERTURA) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                    StringHelper.FormatString(fechaApertura, 20, StringHelper.AlignEnum.AlignLeft)
                    , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Fecha cierre
                var fechaCierre = ReportController.TurnToPrint.
                        FechaCierre == null ? "" : ((DateTime)ReportController.TurnToPrint.
                        FechaCierre).ToString(MultilanguangeController.GetText(MultiLanguageEnum.FORMATO_FECHA_HORA_COMPLETA) );

                e.Graphics.DrawString(
                    StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.FECHA_CIERRE) + ": ", 15, StringHelper.AlignEnum.AlignLeft) +
                    StringHelper.FormatString(fechaCierre, 20, StringHelper.AlignEnum.AlignLeft)
                    , _font, Brushes.Black, _headerTextStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                // Separador
                e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                            Brushes.Black,
                            _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;

                if (_details.Count > 0)
                {
                    List<string> currencies = new();

                    foreach (var item in _details)
                    {
                        if (!currencies.Contains(item.Moneda))
                        {
                            if(item.Cantidad > 0)
                                currencies.Add(item.Moneda);

                        }
                    }
                    string currentCurrency = string.Empty;

                    foreach (var currency in currencies)
                    {
                        yOffset += _interlineSpace;

                        if (!currentCurrency.Equals(currency))
                        {
                            amount = 0;
                            currentCurrency = currency;
                        }
                        // Billetes
                        e.Graphics.DrawString(MultilanguangeController.GetText(MultiLanguageEnum.BILLETE) + " " + currentCurrency +  ": ", _boldFont,
                        Brushes.Black,
                        _detailStart_X, yOffset, new StringFormat());

                        yOffset += _interlineSpace;


                        e.Graphics.DrawString(
                         //"DENOMINACION CANTIDAD TOTAL"
                         StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.DENOMINACION).Substring(0, 5), 5, StringHelper.AlignEnum.AlignLeft) +
                         StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.CANTIDAD).Substring(0, 4), 10, StringHelper.AlignEnum.AlignRight) +
                         StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.TOTAL), 17, StringHelper.AlignEnum.AlignRight)
                         , _font, Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                        // Separador
                        e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                                    Brushes.Black,
                                    _detailStart_X, yOffset, new StringFormat());

                        yOffset += _interlineSpace;

                        foreach (var item in _details)
                        {

                            if (item.Cantidad > 0 && item.Moneda.Equals(currentCurrency))
                            {
                                var partialAmount = item.Cantidad * item.UnidadesDenominacion;
                                amount += item.Cantidad * item.UnidadesDenominacion;

                                var data =
                                StringHelper.FormatString(item.Moneda, 4, StringHelper.AlignEnum.AlignLeft) +
                                StringHelper.FormatString(item.Denominacion, 5, StringHelper.AlignEnum.AlignRight) +
                                StringHelper.FormatString(item.Cantidad.ToString(), 7, StringHelper.AlignEnum.AlignRight) +
                                StringHelper.FormatString(partialAmount.ToString(), 17, StringHelper.AlignEnum.AlignRight);

                                e.Graphics.DrawString(data, _font, Brushes.Black, _detailStart_X, yOffset, new StringFormat());


                                yOffset += _interlineSpace;
                            }
                        }

                        // Separador
                        e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                                Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                        yOffset += _interlineSpace;

                        // Total
                        var totalAmount = StringHelper.FormatString("Total " + currency + ": ", 13, StringHelper.AlignEnum.AlignLeft) +
                            StringHelper.FormatString(amount.ToString(), 20, StringHelper.AlignEnum.AlignRight);

                        e.Graphics.DrawString(totalAmount, _boldFont,
                            Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                        yOffset += _interlineSpace;



                    }
                }
                if (_header.Count > 0)
                {
                    // Separador
                    e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                            Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                    yOffset += _interlineSpace;
                    // sobres
                    e.Graphics.DrawString(MultilanguangeController.GetText(MultiLanguageEnum.SOBRE) + ": ", _boldFont,
                                Brushes.Black,
                                _detailStart_X, yOffset, new StringFormat());

                    yOffset += _interlineSpace;

                    // Separador
                    e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                                Brushes.Black,
                                _detailStart_X, yOffset, new StringFormat());

                    e.Graphics.DrawString(
                     //"MONEDA DENOMINACION CANTIDAD"
                     StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.MONEDA), 10, StringHelper.AlignEnum.AlignLeft) +
                     StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.DENOMINACION).Substring(0, 8) + ".", 10, StringHelper.AlignEnum.AlignLeft) +
                     StringHelper.FormatString(MultilanguangeController.GetText(MultiLanguageEnum.CANTIDAD), 13, StringHelper.AlignEnum.AlignRight)

                     , _font, Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                    yOffset += _interlineSpace;

  
                    foreach (var item in _header)
                    {
                        var data =
                            StringHelper.FormatString(((Permaquim.Depositary.UI.Desktop.Entities.BagContentItem)item).Moneda.Substring(0, 8) + ".", 10, StringHelper.AlignEnum.AlignLeft) +
                            StringHelper.FormatString(((Permaquim.Depositary.UI.Desktop.Entities.BagContentItem)item).Denominacion, 10, StringHelper.AlignEnum.AlignLeft) +
                            StringHelper.FormatString(((Permaquim.Depositary.UI.Desktop.Entities.BagContentItem)item).Cantidad.ToString(), 13, StringHelper.AlignEnum.AlignRight);

                        e.Graphics.DrawString(data, _font, Brushes.Black, _detailStart_X, yOffset, new StringFormat());

                        yOffset += _interlineSpace;
                    }


                    // Separador
                    e.Graphics.DrawString(new String(LINE, MAXCHARACTERLENGHT), _boldFont,
                                Brushes.Black,
                                _detailStart_X, yOffset, new StringFormat());

                }
 
                yOffset += _interlineSpace;


                // Instancia (ORIGINAL / COPIA)
                e.Graphics.DrawString(_copyInstance, _boldFont,
            Brushes.Black,
            _headerTextStart_X, yOffset, new StringFormat());
                yOffset += _interlineSpace;

                //Pie
                e.Graphics.DrawString(DateTime.Now.ToString(_fechaHora) + SPACE + _ticket.TextoPie,
                    _font, Brushes.Black,
                _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;
                // Separador
                e.Graphics.DrawString(new String(STAR, MAXCHARACTERLENGHT), _boldFont,
                            Brushes.Black,
                            _detailStart_X, yOffset, new StringFormat());
                for (int i = 0; i < _ticket.LineasAlFinal; i++)
                {
                    e.Graphics.DrawString(new String(' ', _ticket.AnchoDetalle), _boldFont,
                        Brushes.Black,
                        _detailStart_X, yOffset, new StringFormat());
                    yOffset += _interlineSpace;
                }


            }
            catch (Exception ex)
            {
                FormsController.SetInformationMessage(InformationTypeEnum.Error, ex.Message);
                AuditController.Log(ex);
            }
        }

    }
}


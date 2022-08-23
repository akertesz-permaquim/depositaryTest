using Permaquim.Depositary.UI.Desktop.Helpers;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Permaquim.Depositary.UI.Desktop.Controllers
{
    internal static class ReportController
    {
        private static Image _image;
        private static Font _font;
        private static Font _totalFont;
        private static Rectangle _rectangle;
        private static int _headerTextStart_X;
        private static int _detailStart_X;
        private static int _interlineSpace;

        private static Depositario.Entities.Relations.Operacion.Transaccion _header;
        private static List<Depositario.Entities.Relations.Operacion.TransaccionDetalle> _details;
        private static Depositario.Entities.Tables.Impresion.Ticket _ticket;

        public static void PrintReport(ReportTypeEnum report,
            Depositario.Entities.Tables.Operacion.Transaccion header)
        {
             _header = DatabaseController.GetTransactionHeader(header.Id);
            _details = DatabaseController.GetTransactionDetails(header.Id);

            Depositario.Business.Tables.Impresion.Ticket ticket = new();

            ticket.Items();
            if (ticket.Result.Count > 0)
            {
                _ticket = ticket.Result.FirstOrDefault();

                _image = ImageFromBase64Helper.GetImageFromBase64String(_ticket.Imagen);
                _font = new Font(_ticket.NombreFuenteCabecera, _ticket.TamanioFuenteCabecera);
                _totalFont = new Font(_font.Name, _font.Size, FontStyle.Bold);

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

            }

            PrintDocument printDocument = new PrintDocument();

            PaperSize paperSize = new PaperSize("Custom",
            _ticket.AnchoReporte,
            _ticket.FactorAltoReporte * 
            (_details.Count + 6) // 6 = Líneas de detalle de depósito
             );

            paperSize.RawKind = (int)PaperKind.Custom;

            printDocument.DefaultPageSettings.PaperSize = paperSize;

            printDocument.PrintPage += PrintDocument_PrintPage;

            printDocument.Print();

        }

        private static void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

            decimal amount = 0;
            int yOffset;
            const int MaxCharacterLenght = 33;

            // dibuja el gráfico
            e.Graphics.DrawImage(_image, _rectangle);
            yOffset = _rectangle.Height + _interlineSpace;

            // Graba el texto de cabecera con el offset del alto del gráfico
            e.Graphics.DrawString(_ticket.TextoCabecera, _font,
            Brushes.Black,
            _headerTextStart_X, yOffset  , new StringFormat());
            yOffset += _interlineSpace;


            // Separador
             e.Graphics.DrawString(new String('_', MaxCharacterLenght), _totalFont,
                        Brushes.Black,
                        _detailStart_X, yOffset, new StringFormat());

            yOffset += _interlineSpace;

            // Referencia
            e.Graphics.DrawString(
             MultilanguangeController.GetText(MultiLanguageEnum.TURNO) + ": " + 
             DatabaseController.CurrentTurn.TurnoDepositarioId.EsquemaDetalleTurnoId.Nombre
              , _font,
            Brushes.Black,
            _headerTextStart_X, yOffset, new StringFormat());
            yOffset += _interlineSpace;

            // Importe
            for (int i = 0; i < _details.Count; i++)
            {
                amount += _details[i].CantidadUnidades *
                _details[i].DenominacionId.Unidades;
            }

             e.Graphics.DrawString(
             MultilanguangeController.GetText(MultiLanguageEnum.IMPORTE) + ": " + amount.ToString("C2")
              , _font,
            Brushes.Black,
            _headerTextStart_X, yOffset, new StringFormat());
            yOffset += _interlineSpace;

            // Transacción
            e.Graphics.DrawString(
             MultilanguangeController.GetText(MultiLanguageEnum.CODIGO) + ": " + _header.Id.ToString()
              , _font,
            Brushes.Black,
            _headerTextStart_X, yOffset, new StringFormat());
            yOffset += _interlineSpace;

            // Usuario
            e.Graphics.DrawString(
             MultilanguangeController.GetText(MultiLanguageEnum.USUARIO) + ": " + _header.UsuarioId.NombreApellido
              , _font,
            Brushes.Black,
            _headerTextStart_X, yOffset, new StringFormat());
            yOffset += _interlineSpace;

            // Sucursal
            e.Graphics.DrawString(
             MultilanguangeController.GetText(MultiLanguageEnum.SUCURSAL) + ": " + 
                _header.DepositarioId.SectorId.SucursalId.Nombre
              , _font,
            Brushes.Black,
            _headerTextStart_X, yOffset, new StringFormat());
            yOffset += _interlineSpace;

            // Terminal
            e.Graphics.DrawString(
             MultilanguangeController.GetText(MultiLanguageEnum.DEPOSITARIO) + ": " +
                _header.DepositarioId.CodigoExterno
              , _font,
            Brushes.Black,
            _headerTextStart_X, yOffset, new StringFormat());
            
            yOffset += _interlineSpace;

            // Separador
            e.Graphics.DrawString(new String('_', MaxCharacterLenght), _totalFont,
                        Brushes.Black,
                        _detailStart_X, yOffset, new StringFormat());

            yOffset += _interlineSpace;

            e.Graphics.DrawString(
                //"DENOMINACION CANTIDAD TOTAL"
                String.Format("{0,-10}\t{1,-10}\t{2,5}",
                MultilanguangeController.GetText(MultiLanguageEnum.DENOMINACION),
                MultilanguangeController.GetText(MultiLanguageEnum.CANTIDAD),
                MultilanguangeController.GetText(MultiLanguageEnum.TOTAL))
                , _font,
           Brushes.Black,
           _detailStart_X, yOffset, new StringFormat());

            yOffset += _interlineSpace;

            // Separador
            e.Graphics.DrawString(new String('_', MaxCharacterLenght), _totalFont,
                        Brushes.Black,
                        _detailStart_X, yOffset, new StringFormat());

            yOffset += _interlineSpace;

            // Detalles
            for (int i = 0; i < _details.Count; i++)
            {
                var textLen = MaxCharacterLenght - (_details[i].DenominacionId.MonedaId.Codigo.Length +
                    _details[i].DenominacionId.Nombre.Length +
                    _details[i].CantidadUnidades.ToString().Length +
                    (_details[i].CantidadUnidades * _details[i].DenominacionId.Unidades).ToString().Length );

                e.Graphics.DrawString(
                String.Format("{0,-10}\t{1,-10}\t{2,-10}\t{3,5}",
                    _details[i].DenominacionId.MonedaId.Codigo, 
                    _details[i].DenominacionId.Nombre, 
                    _details[i].CantidadUnidades.ToString(),
                       (_details[i].CantidadUnidades * _details[i].DenominacionId.Unidades).ToString("C2"))
                        ,_font,
                    Brushes.Black,
                    _detailStart_X, yOffset, new StringFormat());

                yOffset += _interlineSpace;
            }
            yOffset += _interlineSpace;

            // Separador
            e.Graphics.DrawString(new String('_', MaxCharacterLenght), _totalFont,
                    Brushes.Black,
                    _detailStart_X, yOffset, new StringFormat());

            yOffset += _interlineSpace;

            // Total
            e.Graphics.DrawString("Total: " + amount.ToString("C2"), _totalFont,
                    Brushes.Black,
                    _detailStart_X, yOffset, new StringFormat());

            yOffset += _interlineSpace;
            
            // Separador
            e.Graphics.DrawString(new String('_', MaxCharacterLenght), _totalFont,
                     Brushes.Black,
                     _detailStart_X, yOffset, new StringFormat());

            yOffset += _interlineSpace;

            //Pie
            e.Graphics.DrawString(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "\t" + _ticket.TextoPie, 
                _font, Brushes.Black,
            _detailStart_X, yOffset, new StringFormat());

        }

    }
}


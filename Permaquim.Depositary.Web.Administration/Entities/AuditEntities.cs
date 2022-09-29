namespace Permaquim.Depositary.Web.Administration.Entities
{
    public class AuditEntities
    {
        public enum LogTypeEnum
        {
            None,
            Exception,
            Information,
            Navigation
        }

        public const long APPLICATION_ID = 1;
    }
}

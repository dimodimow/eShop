using System;

namespace eShop.Common
{
    public static class Helper
    {
        public static void CheckIsEntityNull(object entity, string message)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}

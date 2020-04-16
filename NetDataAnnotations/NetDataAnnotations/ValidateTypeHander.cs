using System.Linq;

namespace NetDataAnnotations
{
    public static class ValidateTypeHander
    {
        public static bool IsValidate(object[] groups, object model)
        {
            return (groups != null && groups.Where(x => x == model).Count() > 0) ? true : false; ;
        }
    }
}
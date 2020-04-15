
using System;
using System.ComponentModel;

namespace NetDataAnnotations
{
    public static class Enums
    {

        /// <summary>
        /// 接口返回状态码
        /// </summary>
        public enum OPCode
        {

            /// <summary>
            /// 操作成功
            /// </summary>
            [MyDescription("message:success")]
            SUCCESS = 200,
            /// <summary>
            /// 操作失败
            /// </summary>
            [MyDescription("message:fail")]
            FAIL = 202,
            /// <summary>
            /// 无权限
            /// </summary>
            [MyDescription("message:unauthorized")]
            UNAUTHORIZED = 403,
            /// <summary>
            /// 参数错误
            /// </summary>
            [MyDescription("message:parameter.error")]
            PARAMETER_ERROR = 400,
            /// <summary>
            /// 签名无效
            /// </summary>
            [MyDescription("message:unsignature")]
            UNSIGNATURE = 401,
            /// <summary>
            /// 数据不存在
            /// </summary>
            [MyDescription("message:data.unexist")]
            DATA_UNEXIST = 404,
            /// <summary>
            /// 数据已存在
            /// </summary>
            [MyDescription("message:data.exist")]
            DATA_EXIST = 409,
            /// <summary>
            /// 请求数据格式不支持
            /// </summary>
            [MyDescription("message:unsupported")]
            UNSUPPORTED = 415,
            /// <summary>
            /// 系统内部异常
            /// </summary>
            [MyDescription("message:system.error")]
            SYSTEM_ERROR = 500,
            /// <summary>
            /// 系统方法未定义无法访问
            /// </summary>
            [MyDescription("message:system.define")]
            SYSTEM_DEFINE = 501,

            /// <summary>
            /// 系统超时 熔断器统一返回状态码
            /// </summary>
            [MyDescription("message:system.timeout")]
            SYSTEM_TIMEOUT = 504

        }

        /// <summary>
        /// 目前提供三种级别	ROLE:角色级别 PERMISSION:权限级别 OPERATION:操作（方法）级别
        /// </summary>
        public enum Level
        {
            /**
             * 角色级别，指安全控制只精确到角色这一级
             */
            ROLE,
            /**
             * 权限级别，指安全控制只精确到权限这一级
             */
            PERMISSION,
            /**
             * 操作级别，指安全控制只精确到操作（方法）这一级
             */
            OPERATION
        }

        public static string GetOPCodeDescription(object enumValue)
        {
            try
            {
                Type enumType = typeof(OPCode);
                return GetDescriptionFromEnumValue(enumType, (int)enumValue);
            }
            catch
            {
                return "未知";
            }
        }


        private static string GetDescriptionFromEnumValue(Type enumType, object enumValue)
        {
            object o = Enum.Parse(enumType, enumValue.ToString());
            string name = o.ToString();
            DescriptionAttribute[] customAttributes = (DescriptionAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(DescriptionAttribute), false);
            if ((customAttributes != null) && (customAttributes.Length == 1))
            {
                return customAttributes[0].Description;
            }
            return name;
        }
    }
}

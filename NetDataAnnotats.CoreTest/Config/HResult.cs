using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetDataAnnotats.CoreTest.Config
{
    public class HResult
    {
        private object code;
        private dynamic data = "";
        private string msg = "";


        /// <summary>
        /// 设置状态编码
        /// </summary>
        /// <param name="value"></param>
        public object Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }


        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="value"></param>
        public dynamic Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }

        }

        /// <summary>
        /// 消息
        /// </summary>
        public string Msg
        {
            get
            {               
                return msg;
            }
            set
            {
                msg = value;
            }
        }
    }
}

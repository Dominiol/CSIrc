﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSIrc
{
    static class MessageProcessing
    {
        public static MethodInfo GetMethod(string _str)
        {
            MethodInfo oMethodInfo = null;
            Type oType = typeof(MessageProcessingMethods);
            MethodInfo[] aoInfo = oType.GetMethods();

            foreach (MethodInfo oInfo in aoInfo)
            {
                var oAttributes = oInfo.GetCustomAttributes(typeof(MessageProcessorAttribute), false);

                if (oAttributes == null || oAttributes.Count() == 0)
                {
                    continue;
                }

                foreach (MessageProcessorAttribute oAttribute in oAttributes)
                {
                    if (oAttribute.Property == _str)
                    {
                        oMethodInfo = oInfo;
                        break;
                    }
                }
            }

            return oMethodInfo;
        }
    }
}

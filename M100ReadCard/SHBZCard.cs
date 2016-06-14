using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace M100ReadCard
{
    class SHBZCard
    {
        [DllImport("SHBZK\\Si_ReadBasic.dll", EntryPoint = "iReadPersonPublicInfo", CharSet = CharSet.Ansi)]
        public static extern int iReadPersonPublicInfo(StringBuilder SHBZHM, StringBuilder XM, StringBuilder XB, StringBuilder MZ, StringBuilder CSD, StringBuilder CSRQ, StringBuilder pErrMsg);
    }
}

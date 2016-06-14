using System;
using System.Text;
using System.Runtime.InteropServices;

namespace M100ReadCard
{
    public class M100IC_DLL
    {
        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_GetSysVersion", CharSet = CharSet.Ansi)]
        public static extern int M100_GetSysVersion(IntPtr ComHandle, StringBuilder strVersion);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_CommOpen", CharSet = CharSet.Ansi)]//打开端口
        public static extern IntPtr M100_CommOpen(string port);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_CommOpenWithBaud", CharSet = CharSet.Ansi)]//打开端口（设置固定波特率 默认9600）
        public static extern IntPtr M100_CommOpenWithBaud(string port, int data);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_CommClose", CharSet = CharSet.Ansi)]//关闭端口
        public static extern int M100_CommClose(IntPtr ComHandle);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_Reset", CharSet = CharSet.Ansi)]
        public static extern int M100_Reset(IntPtr ComHandle,byte _PM, byte[] _VerCode);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_SetCommBaud", CharSet = CharSet.Ansi)]
        public static extern int M100_SetCommBaud(IntPtr ComHandle, int _Baud);

        //out]_Position 卡片的位置值，对应如下：
        //=0x30：卡片在前端不夹卡位置。
        //=0x31：卡片在前端夹卡位置。
        //=0x32：卡片在读卡机射频卡位置。
        //=0x33：卡片在IC卡位置。
        //=0x34：卡片在后端夹卡位置。
        //=0x35：读卡机内无卡。
        //=0x36：卡不在标准位置
        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_CheckCardPosition", CharSet = CharSet.Ansi)]
        public static extern int M100_CheckCardPosition(IntPtr ComHandle, byte[] _Position);


            //[out]_States[7] 七个传感器的值，对应顺序如下：
            //PSS1 =0x30：无卡，=0x31：有卡
            //PSS2 =0x30：无卡，=0x31：有卡
            //PSS3 =0x30：无卡，=0x31：有卡
            //PSS4 =0x30：无卡，=0x31：有卡
            //PSS5 =0x30：无卡，=0x31：有卡
            //CTKSW =0x30：无卡，=0x31：有卡
            //KSW =0x30：无卡，=0x31：有卡
        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_CheckSensorStates", CharSet = CharSet.Ansi)]
        public static extern int M100_CheckSensorStates(IntPtr ComHandle, byte[] _States);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_EnterCard", CharSet = CharSet.Ansi)]
        public static extern int M100_EnterCard(IntPtr ComHandle, byte EnterType, int WaitTime);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_MoveCard", CharSet = CharSet.Ansi)]
        public static extern int M100_MoveCard(IntPtr ComHandle, byte _PM);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_AutoTestICCard", CharSet = CharSet.Ansi)]
        public static extern int M100_AutoTestICCard(IntPtr ComHandle, byte[] _States);


        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_IcCardPowerOn", CharSet = CharSet.Ansi)]
        public static extern int M100_IcCardPowerOn(IntPtr ComHandle);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_IcCardPowerOff", CharSet = CharSet.Ansi)]
        public static extern int M100_IcCardPowerOff(IntPtr ComHandle);


        //SLE4442 卡操作函数
        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_SLE4442Reset", CharSet = CharSet.Ansi)]
        public static extern int M100_SLE4442Reset(IntPtr ComHandle);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_SLE4442VerifyPWD", CharSet = CharSet.Ansi)]
        public static extern int M100_SLE4442VerifyPWD(IntPtr ComHandle, byte[] _PWData);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_SLE4442Read", CharSet = CharSet.Ansi)]
        public static extern int M100_SLE4442Read(IntPtr ComHandle, int _Address, int _dataLen, byte[] _BlockData);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_SLE4442ReadProtectBit", CharSet = CharSet.Ansi)]
        public static extern int M100_SLE4442ReadProtectBit(IntPtr ComHandle, StringBuilder _BlockData);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_SLE4442ReadSafety", CharSet = CharSet.Ansi)]
        public static extern int M100_SLE4442ReadSafety(IntPtr ComHandle, StringBuilder _BlockData);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_SLE4442Write", CharSet = CharSet.Ansi)]
        public static extern int M100_SLE4442Write(IntPtr ComHandle, int _Address, int _dataLen, byte[] _BlockData);


        //SLE4428 卡操作函数
        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_Sle4428Reset", CharSet = CharSet.Ansi)]
        public static extern int M100_Sle4428Reset(IntPtr ComHandle);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_Sle4428VerifyPWD", CharSet = CharSet.Ansi)]
        public static extern int M100_Sle4428VerifyPWD(IntPtr ComHandle, byte[] _PWData);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_Sle4428Read", CharSet = CharSet.Ansi)]
        public static extern int M100_Sle4428Read(IntPtr ComHandle, int _Address, int _dataLen, StringBuilder _BlockData);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_Sle4428ReadProtectBit", CharSet = CharSet.Ansi)]
        public static extern int M100_Sle4428ReadProtectBit(IntPtr ComHandle, StringBuilder _BlockData);

    
        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_Sle4428Write", CharSet = CharSet.Ansi)]
        public static extern int M100_Sle4428Write(IntPtr ComHandle, int _Address, int _dataLen, byte[] _BlockData);
        
        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_CpuCardColdReset", CharSet = CharSet.Ansi)]
        public static extern int M100_CpuCardColdReset(IntPtr ComHandle, byte[] _CPUType, byte[] _RstData, byte[] _RstdataLen);







        //------磁卡操作函数------------------------------------------------------

        //[DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_ReadMagcardDecode", CharSet = CharSet.Ansi)]
        //public static extern int M100_ReadMagcardDecode(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, byte _track, byte[] _DataLen, StringBuilder _BlockData, StringBuilder RecordInfo);

        //[DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_ReadMagcardUNDecode", CharSet = CharSet.Ansi)]
        //public static extern int M100_ReadMagcardUNDecode(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, byte _track, uint _DataLen, byte[] _BlockData, StringBuilder RecordInfo);

        //[DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_ClearMagCardData", CharSet = CharSet.Ansi)]
        //public static extern int M100_ClearMagCardData(IntPtr ComHandle, bool bHasMac_Addr, byte Mac_Addr, StringBuilder RecordInfo);

        //射频卡操作
        //S50
        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S50DetectCard", CharSet = CharSet.Ansi)]
        public static extern int M100_S50DetectCard(IntPtr ComHandle);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S50GetCardID", CharSet = CharSet.Ansi)]
        public static extern int M100_S50GetCardID(IntPtr ComHandle, byte[] _CardID);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S50LoadSecKey", CharSet = CharSet.Ansi)]
        public static extern int M100_S50LoadSecKey(IntPtr ComHandle, byte _BlockAddr, byte _KEYType, byte[] _KEY);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S50ReadBlock", CharSet = CharSet.Ansi)]
        public static extern int M100_S50ReadBlock(IntPtr ComHandle, byte _Block, byte[] _BlockData);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S50WriteBlock", CharSet = CharSet.Ansi)]
        public static extern int M100_S50WriteBlock(IntPtr ComHandle, byte _Block, byte[] _BlockData);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S50InitValue", CharSet = CharSet.Ansi)]
        public static extern int M100_S50InitValue(IntPtr ComHandle, byte _Block, byte[] _Data);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S50Increment", CharSet = CharSet.Ansi)]
        public static extern int M100_S50Increment(IntPtr ComHandle, byte _Block, byte[] _Data);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S50Decrement", CharSet = CharSet.Ansi)]
        public static extern int M100_S50Decrement(IntPtr ComHandle, byte _Block, byte[] _Data);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S50Halt", CharSet = CharSet.Ansi)]
        public static extern int M100_S50Halt(IntPtr ComHandle);

        //S70
        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S70DetectCard", CharSet = CharSet.Ansi)]
        public static extern int M100_S70DetectCard(IntPtr ComHandle);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S70GetCardID", CharSet = CharSet.Ansi)]
        public static extern int M100_S70GetCardID(IntPtr ComHandle, byte[] _CardID);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S70LoadSecKey", CharSet = CharSet.Ansi)]
        public static extern int M100_S70LoadSecKey(IntPtr ComHandle, byte _BlockAddr, byte _KEYType, byte[] _KEY);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S70ReadBlock", CharSet = CharSet.Ansi)]
        public static extern int M100_S70ReadBlock(IntPtr ComHandle, byte _Block, byte[] _BlockData);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S70WriteBlock", CharSet = CharSet.Ansi)]
        public static extern int M100_S70WriteBlock(IntPtr ComHandle, byte _Block, byte[] _BlockData);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S70InitValue", CharSet = CharSet.Ansi)]
        public static extern int M100_S70InitValue(IntPtr ComHandle, byte _Block, byte[] _Data);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S70Increment", CharSet = CharSet.Ansi)]
        public static extern int M100_S70Increment(IntPtr ComHandle, byte _Block, byte[] _Data);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S70Decrement", CharSet = CharSet.Ansi)]
        public static extern int M100_S70Decrement(IntPtr ComHandle, byte _Sec, byte _Block, byte[] _Data);

        [DllImport("M100_DLL\\M100_DLL.dll", EntryPoint = "M100_S70Halt", CharSet = CharSet.Ansi)]
        public static extern int M100_S70Halt(IntPtr ComHandle);       

    }
}

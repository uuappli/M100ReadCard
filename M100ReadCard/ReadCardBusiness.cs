using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace M100ReadCard
{
    class ReadCardBusiness
    {
        /// <summary>
        /// 读卡器初始化
        /// </summary>
        /// <param name="add">机器地址 0——15</param>
        /// <returns>返回串口句柄</returns>
        public IntPtr Init(int port)
        {
            string _port = "com" + port;
            IntPtr hadler = M100IC_DLL.M100_CommOpenWithBaud(_port, 9600);
            return hadler;
        }

        /// <summary>
        /// 检查卡机状态
        /// </summary>
        /// <returns></returns>
        public bool CheckCardPosition(IntPtr hadler)
        {
            try
            {
                byte[] ByteArray2 = new byte[2];
                int i = M100IC_DLL.M100_CheckCardPosition(hadler, ByteArray2);
                if (i != 0)
                {
                    //MyMsg.MsgInfo("读取卡片在机器里的位置失败");
                    return false;
                }

                string state = string.Empty;
                switch (ByteArray2[0])
                {
                    case 0x30:
                        state = "卡片在前端不夹卡位置";
                        break;
                    case 0x31:
                        state = "卡片在前端夹卡位置";
                        break;
                    //case 0x32:
                    //    state = "卡片在读卡机射频卡位置";
                    //    break;
                    //case 0x33:
                    //    state = "卡片在IC卡位置";
                    //    break;
                    case 0x34:
                        state = "卡片在后端夹卡位置";
                        break;
                    case 0x35:
                        state = "读卡机内无卡";
                        break;
                    case 0x36:
                        state = "卡不在标准位置";
                        break;

                }


                if (state != string.Empty)
                {
                    //MyMsg.MsgInfo(state);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        public string ReadCard()
        {
            string cardNo = string.Empty;
            string port = "1";
            IntPtr hadler = Init(Convert.ToInt32(port));
            if (hadler.ToInt32() == 0)
            {
                //MyMsg.MsgInfo("端口打开失败！");
                return "端口打开失败！";
            }

            try
            {
                int i = M100IC_DLL.M100_EnterCard(hadler, 0x30, 3000);
                int j = 0;
                if (i != 0)
                {
                    //MyMsg.MsgInfo("进卡失败");
                    return "进卡失败";
                }

                i = M100IC_DLL.M100_MoveCard(hadler, 0x31);
                if (i != 0)
                {
                    j = M100IC_DLL.M100_MoveCard(hadler, 0x32);
                    if (j != 0)
                    {
                        return "退卡失败";
                    }
                    //MyMsg.MsgInfo("卡片传动IC卡位失败");
                    return "卡片传动IC卡位失败" + i;
                }

                byte[] _cputype = new byte[1];
                byte[] _rstData = new byte[88];
                byte[] _rstdataLen = new byte[1];
                i = M100IC_DLL.M100_CpuCardColdReset(hadler, _cputype, _rstData, _rstdataLen);
                if (i == 0)
                {
                    //StringBuilder SHBZHM = new StringBuilder(1024);
                    //StringBuilder XM = new StringBuilder(1024);
                    //StringBuilder XB = new StringBuilder(1024);
                    //StringBuilder MZ = new StringBuilder(1024);
                    //StringBuilder CSD = new StringBuilder(1024);
                    //StringBuilder CSRQ = new StringBuilder(1024);
                    //StringBuilder pErrMsg = new StringBuilder(1024);
                    //byte[] iDNum = new byte[9];
                    //i = M100IC_DLL.M100_AutoReadSocialSecurityCardID(hadler, iDNum);
                    //if (i != 0)
                    //{
                    //    j = M100IC_DLL.M100_MoveCard(hadler, 0x32);
                    //    if (j != 0)
                    //    {
                    //        return "退卡失败";
                    //    }
                    //    return "读取社保号失败 " + i;
                    //}

                    //i = M100IC_DLL.M100_MoveCard(hadler, 0x32);
                    //if (i != 0)
                    //{
                    //    return "退卡失败";
                    //}

                    //try
                    //{
                    //    cardNo = SHBZHM.ToString();
                    //}
                    //catch
                    //{
                    //    return "卡片数据错误！或卡插入方向不正确";
                    //}

                    //i = M100IC_DLL.M100_IcCardPowerOn(hadler);
                    //if (i != 0)
                    //{
                    //    //MyMsg.MsgInfo("上电失败");
                    //    return "上电失败";
                    //}

                    //byte[] buf = new byte[3];
                    //buf[0] = Convert.ToByte("FF", 16);
                    //buf[1] = Convert.ToByte("FF", 16);
                    //buf[2] = Convert.ToByte("FF", 16);
                    //i = M100IC_DLL.M100_SLE4442VerifyPWD(hadler, buf);
                    //if (i != 0)
                    //{
                    //    //MyMsg.MsgInfo("密码验证失败");
                    //    return "密码验证失败";
                    //}

                    byte[] iDNum = new byte[9];
                    i = M100IC_DLL.M100_AutoReadSocialSecurityCardID(hadler, iDNum);
                    if (i != 0)
                    {
                        j = M100IC_DLL.M100_MoveCard(hadler, 0x32);
                        if (j != 0)
                        {
                            return "退卡失败";
                        }

                        return "读卡失败" + i;
                    }

                    //i = M100IC_DLL.M100_IcCardPowerOff(hadler);
                    //if (i != 0)
                    //{
                    //    //MyMsg.MsgInfo("下电失败");
                    //    return "下电失败";
                    //}

                    i = M100IC_DLL.M100_MoveCard(hadler, 0x32);
                    if (i != 0)
                    {
                        //MyMsg.MsgInfo("退卡失败");
                        return "退卡失败" + i;
                    }

                    try
                    {

                        string msg = Encoding.ASCII.GetString(iDNum);
                        //string returnstr = Pub.Decrypt(msg, "SOFT-HIS");
                        cardNo = msg;
                    }
                    catch
                    {
                        //MyMsg.MsgInfo("卡片数据错误！或卡插入方向不正确");
                        return "卡片数据错误！或卡插入方向不正确";
                    }
                }
                else
                {
                    i = M100IC_DLL.M100_MoveCard(hadler, 0x30);
                    if (i != 0)
                    {
                        j = M100IC_DLL.M100_MoveCard(hadler, 0x32);
                        if (j != 0)
                        {
                            return "退卡失败";
                        }
                        return "卡片传动射频卡位失败" +i;
                    }

                    i = M100IC_DLL.M100_S50DetectCard(hadler);
                    if (i != 0)
                    {
                        j = M100IC_DLL.M100_MoveCard(hadler, 0x32);
                        if (j != 0)
                        {
                            return "退卡失败";
                        }
                        return "寻卡失败" + i;
                    }

                    byte[] _cardid = new byte[4];
                    i = M100IC_DLL.M100_S50GetCardID(hadler, _cardid);
                    if (i != 0)
                    {
                        j = M100IC_DLL.M100_MoveCard(hadler, 0x32);
                        if (j != 0)
                        {
                            return "退卡失败";
                        }
                        return "读卡片序列号失败" + i;
                    }

                    byte[] key = new byte[6];
                    key[0] = Convert.ToByte("1A", 16);
                    key[1] = Convert.ToByte("2C", 16);
                    key[2] = Convert.ToByte("3B", 16);
                    key[3] = Convert.ToByte("4D", 16);
                    key[4] = Convert.ToByte("5E", 16);
                    key[5] = Convert.ToByte("6F", 16);
                    i = M100IC_DLL.M100_S50LoadSecKey(hadler, Convert.ToByte(1), 0X30, key);
                    if (i != 0)
                    {
                        j = M100IC_DLL.M100_MoveCard(hadler, 0x32);
                        if (j != 0)
                        {
                            return "退卡失败";
                        }
                        return "校验密码失败" + i;
                    }

                    byte[] _blockData = new byte[16];
                    //StringBuilder sbblockData = new StringBuilder(1024);
                    i = M100IC_DLL.M100_S50ReadBlock(hadler, Convert.ToByte(4), _blockData);
                    if (i != 0)
                    {
                        j = M100IC_DLL.M100_MoveCard(hadler, 0x32);
                        if (j != 0)
                        {
                            return "退卡失败";
                        }
                        return "读块数据失败" + i;
                    }

                    i = M100IC_DLL.M100_S50Halt(hadler);
                    if (i != 0)
                    {
                        j = M100IC_DLL.M100_MoveCard(hadler, 0x32);
                        if (j != 0)
                        {
                            return "退卡失败";
                        }
                        return "停机失败" + i;
                    }
                    
                    i = M100IC_DLL.M100_MoveCard(hadler, 0x32);
                    if (i != 0)
                    {
                        return "退卡失败";
                    }

                    try
                    {

                        string msg = Encoding.ASCII.GetString(_blockData);
                        //string msg = sbblockData.ToString();
                        //string returnstr = Pub.Decrypt(msg, "SOFT-HIS");
                        cardNo = msg;
                    }
                    catch
                    {
                        return "卡片数据错误！或卡插入方向不正确" + cardNo;
                    }
                }

                return cardNo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ClosePort(hadler);
            }
        }

        /// <summary>
        /// 关闭端口
        /// </summary>
        /// <param name="hadler">打开的串口句柄</param>
        public void ClosePort(IntPtr hadler)
        {
            int i = M100IC_DLL.M100_CommClose(hadler);
        }
    }
}

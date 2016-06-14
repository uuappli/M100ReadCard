#ifndef _READ_SICARD_H_
#define _READ_SICARD_H_

/*通用函数返回状态*/
#define DC_STATUS_OK 0  //函数正常返回

#define DC_STATUS_ERR_FUN_FAIL -100  //普通函数执行失败

#define DC_STATUS_ERR_PARA_ERR -101  //参数错误

#define DC_STATUS_ERR_MEM_FAILURE -102  //内存分配不足返回码

#define DC_STATUS_ERR_PTR_NULL -103  //入参指针为空(主要针对错误信息指针)

#define REG_MSG_LEN 1024
#define ERR_MSG_LEN 256 

#ifdef __cplusplus
extern "C" {
#endif

/***************************************************
**  Function:        iReadCardPublicInfo 
**  Description:     读取社保卡发卡公共信息。
**  Parameter[out]:  KSBM: 卡识别码
                     KLB: 卡类别
					 GFBB: 规范版本
					 JGBM: 初始化机构代码
					 FKRQ: 发卡日期
					 KYXQ: 卡有效期
					 KH: 卡号
**  Parameter[out]:  pErrMsg: 错误描述
**  Return:          int: 操作成功返回0；否则返回小于0的错误码，            
***************************************************/	
int __stdcall iReadCardPublicInfo(char* KSBM, //卡识别码
								  char* KLB, //卡类别
								  char* GFBB, //规范版本
								  char* JGBM, //初始化机构代码
								  char* FKRQ, //发卡日期
								  char* KYXQ, //卡有效期
								  char* KH, //卡号
								  char* pErrMsg);

/***************************************************
**  Function:        iReadPersonPublicInfo 
**  Description:     读取社保卡持卡人公共信息。
**  Parameter[in]:   Flag: 性别和民族显示格式: 0-编码; 1-汉字
**  Parameter[out]:  SHBZHM: 社会保障号码
**                   XM: 姓名
**                   XB: 性别
**                   MZ: 民族
**                   CSD: 出生地
**                   CSRQ: 出生日期
**                   pErrMsg: 错误描述
**  Return:          int: 操作成功返回0；否则返回小于0的错误码，            
***************************************************/	
int __stdcall iReadPersonPublicInfo(char* SHBZHM,
									char* XM,
									char* XB,
									char* MZ,
									char* CSD,
									char* CSRQ,
									char* pErrMsg);

/***************************************************
**  Function:        iReadIdentityInfo
**  Description:     读取二代证信息
**  Parameter[in]:   pcPhotoPath：照片文件保存路径，若为空则不保存。
**  Parameter[out]:  pName: 姓名
**                   pGeneder: 性别（描述信息）
**                   pNation: 民族（描述信息）
**                   pBirth: 出生日期
**                   pAddress: 户籍地址
**                   pCertNO: 身份证号
**                   pDepartment: 签发机关
**                   pMadedDate: 发卡日期
**                   pExpire: 截至有效期
**                   pPhotoBuffer: 照片数据流.pcPhotoPath为空不生成
**                   pErrMsg：函数执行结果的描述信息： 如”成功”。
**  Return:          int:操作成功返回0；否则返回小于0的错误码          
***************************************************/	
int __stdcall iReadIdentityInfo(const char* pcPhotoPath, //照片文件保存路径，若为空则不存储
								char* pName, 
								char* pGeneder,
								char* pNation,
								char* pBirth,
								char* pAddress,
								char* pCertNO,
								char* pDepartment,
								char* pMadedDate,
								char* pExpire,
								char* pPhotoBuffer, 
								char* pErrMsg);

/***************************************************
**  Function:        iReadPBOCAccount
**  Description:     读金融账号
**  Parameter[out]:  pOutData：个人账户信息
**                   pErrmsg：函数执行结果的描述信息： 如”成功”。
**  Return:          int:操作成功返回0；否则返回小于0的错误码，pErrmsg为错误描述。           
***************************************************/
int __stdcall iReadPBOCAccount(char* pOutData, char* pErrMsg);

/***************************************************
**  Function:        iReadPBOCAccount
**  Description:     读银行卡个人账户和
**  Parameter[out]:  pOutData：个人账户信息
					 pBankNoSnr 个人账户序列号,与个人账户一起确定账户唯一性
**                   pErrmsg：函数执行结果的描述信息： 如”成功”。
**  Return:          int:操作成功返回0；否则返回小于0的错误码，pErrmsg为错误描述。           
***************************************************/
int __stdcall iReadPBOCAccount_Ext(char* pBankNo, char* pBankNoSnr, char* pErrMsg);

/***************************************************
**  Function:        iPKBGetPIN
**  Description:     获取密码键盘输入信息
**  Parameter[out]:  pcErrMsg：函数执行结果的描述信息： 如”成功”。
**  Return:          int:操作成功，返回0；否则，返回小于0的错误码，pcErrMsg为错误描述。
**  Author:          YJZ
**  Date:            2015/12/24
**  Note:            此函数不需要PSAM卡
***************************************************/
int __stdcall iPKBGetPIN (char* pcPass,char* pcErrMsg);

/***************************************************
**  Function:        iVerifyPIN
**  Description:     校验个人PIN码
**  Parameter[in]:   pchPIN：个人PIN码
**  Parameter[out]:  pcErrMsg：函数执行结果的描述信息： 如”成功”。
**  Return:          int:操作成功，返回0；否则，返回小于0的错误码，pcErrMsg为错误描述。
**  Author:          YJZ
**  Date:            2015/12/24
**  Note:            此函数不需要PSAM卡
***************************************************/
int __stdcall iVerifyPIN(const char* pchPIN, char* pcErrMsg);

/***************************************************
**  Function:        iChangePIN
**  Description:     修改个人PIN码
**  Parameter[in]:   pcOldPIN：原密码
**                   pcNewPIN：新密码
**  Parameter[out]:  pcErrMsg：函数执行结果的描述信息： 如”成功”。
**  Return:          int:操作成功，返回0；否则，返回小于0的错误码，pcErrMsg为错误描述。
**  Author:          YJZ
**  Date:            2015/12/24
**  Note:            此函数不需要PSAM卡
***************************************************/
int __stdcall iChangePIN(const char* pcOldPIN, const char* pcNewPIN, char* pcErrMsg);

/***************************************************
**  Function:        iReadMagCard
**  Description:     读取银行卡卡号
**  Parameter[in]:   MagTime：等待用户刷卡时间
**  Parameter[out]:  pcCardNO：银行卡卡号
**                   pcErrMsg：函数执行结果的描述信息： 如”成功”。
**  Return:          int:操作成功，返回0；否则，返回小于0的错误码，pcErrMsg为错误描述。
**  Author:          YJZ
**  Date:            2015/12/24
**  Note:            此函数不需要PSAM卡
***************************************************/
int __stdcall iReadMagCard(const int iMagTime,char * pcCardNO, char* pcErrMsg);

/***************************************************
**  Function:        iReadMedicareNO
**  Description:     读取医保个人账号
**  Parameter[out]:  pcMedicareNum：医保个人账号
**                   pcErrMsg：函数执行结果的描述信息： 如”成功”。
**  Return:          int:操作成功，返回0；否则，返回小于0的错误码，pcErrMsg为错误描述。
**  Author:          YJZ
**  Date:            2015/12/24
**  Note:            此函数需要PSAM卡
***************************************************/
int __stdcall iReadMedicareNO(char* pcMedicareNum, char* pcErrMsg);

/***************************************************
**  Function:        DeviceBeep
**  Description:     设备蜂鸣
**  Parameter[in]:   time: 蜂鸣持续时间(ms),建议取值10
**  Parameter[out]:  pErrMsg: 函数执行结果的描述信息： 如”成功”。
**  Return:          int:操作成功，返回0；否则，返回小于0的错误码
***************************************************/
int __stdcall DeviceBeep(int time, char *pErrMsg);

#ifdef __cplusplus
}
#endif

#endif
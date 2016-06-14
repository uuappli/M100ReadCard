#ifndef _READ_SICARD_H_
#define _READ_SICARD_H_

/*ͨ�ú�������״̬*/
#define DC_STATUS_OK 0  //������������

#define DC_STATUS_ERR_FUN_FAIL -100  //��ͨ����ִ��ʧ��

#define DC_STATUS_ERR_PARA_ERR -101  //��������

#define DC_STATUS_ERR_MEM_FAILURE -102  //�ڴ���䲻�㷵����

#define DC_STATUS_ERR_PTR_NULL -103  //���ָ��Ϊ��(��Ҫ��Դ�����Ϣָ��)

#define REG_MSG_LEN 1024
#define ERR_MSG_LEN 256 

#ifdef __cplusplus
extern "C" {
#endif

/***************************************************
**  Function:        iReadCardPublicInfo 
**  Description:     ��ȡ�籣������������Ϣ��
**  Parameter[out]:  KSBM: ��ʶ����
                     KLB: �����
					 GFBB: �淶�汾
					 JGBM: ��ʼ����������
					 FKRQ: ��������
					 KYXQ: ����Ч��
					 KH: ����
**  Parameter[out]:  pErrMsg: ��������
**  Return:          int: �����ɹ�����0�����򷵻�С��0�Ĵ����룬            
***************************************************/	
int __stdcall iReadCardPublicInfo(char* KSBM, //��ʶ����
								  char* KLB, //�����
								  char* GFBB, //�淶�汾
								  char* JGBM, //��ʼ����������
								  char* FKRQ, //��������
								  char* KYXQ, //����Ч��
								  char* KH, //����
								  char* pErrMsg);

/***************************************************
**  Function:        iReadPersonPublicInfo 
**  Description:     ��ȡ�籣���ֿ��˹�����Ϣ��
**  Parameter[in]:   Flag: �Ա��������ʾ��ʽ: 0-����; 1-����
**  Parameter[out]:  SHBZHM: ��ᱣ�Ϻ���
**                   XM: ����
**                   XB: �Ա�
**                   MZ: ����
**                   CSD: ������
**                   CSRQ: ��������
**                   pErrMsg: ��������
**  Return:          int: �����ɹ�����0�����򷵻�С��0�Ĵ����룬            
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
**  Description:     ��ȡ����֤��Ϣ
**  Parameter[in]:   pcPhotoPath����Ƭ�ļ�����·������Ϊ���򲻱��档
**  Parameter[out]:  pName: ����
**                   pGeneder: �Ա�������Ϣ��
**                   pNation: ���壨������Ϣ��
**                   pBirth: ��������
**                   pAddress: ������ַ
**                   pCertNO: ���֤��
**                   pDepartment: ǩ������
**                   pMadedDate: ��������
**                   pExpire: ������Ч��
**                   pPhotoBuffer: ��Ƭ������.pcPhotoPathΪ�ղ�����
**                   pErrMsg������ִ�н����������Ϣ�� �硱�ɹ�����
**  Return:          int:�����ɹ�����0�����򷵻�С��0�Ĵ�����          
***************************************************/	
int __stdcall iReadIdentityInfo(const char* pcPhotoPath, //��Ƭ�ļ�����·������Ϊ���򲻴洢
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
**  Description:     �������˺�
**  Parameter[out]:  pOutData�������˻���Ϣ
**                   pErrmsg������ִ�н����������Ϣ�� �硱�ɹ�����
**  Return:          int:�����ɹ�����0�����򷵻�С��0�Ĵ����룬pErrmsgΪ����������           
***************************************************/
int __stdcall iReadPBOCAccount(char* pOutData, char* pErrMsg);

/***************************************************
**  Function:        iReadPBOCAccount
**  Description:     �����п������˻���
**  Parameter[out]:  pOutData�������˻���Ϣ
					 pBankNoSnr �����˻����к�,������˻�һ��ȷ���˻�Ψһ��
**                   pErrmsg������ִ�н����������Ϣ�� �硱�ɹ�����
**  Return:          int:�����ɹ�����0�����򷵻�С��0�Ĵ����룬pErrmsgΪ����������           
***************************************************/
int __stdcall iReadPBOCAccount_Ext(char* pBankNo, char* pBankNoSnr, char* pErrMsg);

/***************************************************
**  Function:        iPKBGetPIN
**  Description:     ��ȡ�������������Ϣ
**  Parameter[out]:  pcErrMsg������ִ�н����������Ϣ�� �硱�ɹ�����
**  Return:          int:�����ɹ�������0�����򣬷���С��0�Ĵ����룬pcErrMsgΪ����������
**  Author:          YJZ
**  Date:            2015/12/24
**  Note:            �˺�������ҪPSAM��
***************************************************/
int __stdcall iPKBGetPIN (char* pcPass,char* pcErrMsg);

/***************************************************
**  Function:        iVerifyPIN
**  Description:     У�����PIN��
**  Parameter[in]:   pchPIN������PIN��
**  Parameter[out]:  pcErrMsg������ִ�н����������Ϣ�� �硱�ɹ�����
**  Return:          int:�����ɹ�������0�����򣬷���С��0�Ĵ����룬pcErrMsgΪ����������
**  Author:          YJZ
**  Date:            2015/12/24
**  Note:            �˺�������ҪPSAM��
***************************************************/
int __stdcall iVerifyPIN(const char* pchPIN, char* pcErrMsg);

/***************************************************
**  Function:        iChangePIN
**  Description:     �޸ĸ���PIN��
**  Parameter[in]:   pcOldPIN��ԭ����
**                   pcNewPIN��������
**  Parameter[out]:  pcErrMsg������ִ�н����������Ϣ�� �硱�ɹ�����
**  Return:          int:�����ɹ�������0�����򣬷���С��0�Ĵ����룬pcErrMsgΪ����������
**  Author:          YJZ
**  Date:            2015/12/24
**  Note:            �˺�������ҪPSAM��
***************************************************/
int __stdcall iChangePIN(const char* pcOldPIN, const char* pcNewPIN, char* pcErrMsg);

/***************************************************
**  Function:        iReadMagCard
**  Description:     ��ȡ���п�����
**  Parameter[in]:   MagTime���ȴ��û�ˢ��ʱ��
**  Parameter[out]:  pcCardNO�����п�����
**                   pcErrMsg������ִ�н����������Ϣ�� �硱�ɹ�����
**  Return:          int:�����ɹ�������0�����򣬷���С��0�Ĵ����룬pcErrMsgΪ����������
**  Author:          YJZ
**  Date:            2015/12/24
**  Note:            �˺�������ҪPSAM��
***************************************************/
int __stdcall iReadMagCard(const int iMagTime,char * pcCardNO, char* pcErrMsg);

/***************************************************
**  Function:        iReadMedicareNO
**  Description:     ��ȡҽ�������˺�
**  Parameter[out]:  pcMedicareNum��ҽ�������˺�
**                   pcErrMsg������ִ�н����������Ϣ�� �硱�ɹ�����
**  Return:          int:�����ɹ�������0�����򣬷���С��0�Ĵ����룬pcErrMsgΪ����������
**  Author:          YJZ
**  Date:            2015/12/24
**  Note:            �˺�����ҪPSAM��
***************************************************/
int __stdcall iReadMedicareNO(char* pcMedicareNum, char* pcErrMsg);

/***************************************************
**  Function:        DeviceBeep
**  Description:     �豸����
**  Parameter[in]:   time: ��������ʱ��(ms),����ȡֵ10
**  Parameter[out]:  pErrMsg: ����ִ�н����������Ϣ�� �硱�ɹ�����
**  Return:          int:�����ɹ�������0�����򣬷���С��0�Ĵ�����
***************************************************/
int __stdcall DeviceBeep(int time, char *pErrMsg);

#ifdef __cplusplus
}
#endif

#endif
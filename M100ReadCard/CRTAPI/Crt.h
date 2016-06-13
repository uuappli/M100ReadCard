/*****************************************************/
/* Crt.h                                         	   */
/* Define the Application Program Interface          */
/* for CRT-310-H Card-Reader       	            	   */
/* Created by pbq at 06/05/2006            					 */
/*****************************************************/

#ifndef __CRTAPI__
#define __CRTAPI__

typedef  struct{
	unsigned char len[2];
	unsigned char cmd[2];
	unsigned char param[265];
}CmdType;

typedef struct{
	unsigned char rlen[2];
	unsigned char rcmd[2];
	unsigned char rspdata[1000];
}RspType;

#define STX		0X02
#define ETX		0x03
#define ENQ		0X05
#define ACK		0X06
#define NAK		0x15
#define EOT		0X04
#define IDN		'C'
#define POSITIVE	'P'
#define NEGATIVE	'N'


extern unsigned char	__stdcall	CRTInit(unsigned char port,unsigned char Type);//portΪ���ں�(��0��ʼ),TypeΪ�������п��Ĵ���ʽ,0����,1ǰ�˿�,2���˿�
extern unsigned char	__stdcall	CardSetting(unsigned char CardIn,unsigned char EnableBackIn);
/*CardIn:����ǰ�˽�����ʽ
1 	��ֹǰ�˽���
2		�ſ���ʽ����ʹ��
3		���ط�ʽ����ʹ��,����ſ�, ic��,m1����
4		���źŷ�ʽ����,��Դű�����һЩֽ������
EnableBackIn:�����Ƿ������˽���
0 	�ʳ��˽���
1		��ֹ��˽���
*/
extern	unsigned char	__stdcall	GetCardReaderStatus(unsigned char *atPosition);
/*
	atPosition:	=0x30����Ƭ��ǰ�˲��п�λ�á�
				=0x31����Ƭ��ǰ�˼п�λ�á�
				=0x32����Ƭ�ڶ�������Ƶ��λ�á�
				=0x33����Ƭ��IC��λ�á�
				=0x34����Ƭ�ں�˼п�λ�á�
				=0x35�����������޿���
				=0x36�������ڱ�׼λ��
*/
extern	unsigned char	__stdcall	CheckICTypeCheckICType(unsigned char *CARDTP);
/*
	rspType:����ֵ,1�ֽ�
	CARDTP=0X30��AT24C01
CARDTP=0X31��AT24C02
CARDTP=0X32��AT24C04
CARDTP=0X33��AT24C08
CARDTP=0X34��AT24C16
CARDTP=0X35��AT24C32
CARDTP=0X36��AT24C64
CARDTP=0X37��AT45DB041
CARDTP=0X38��AT102
CARDTP=0X39��AT1604
CARDTP=0X3A��AT1608
CARDTP=0X3B��SLE4442
CARDTP=0X3C��SLE4428
CARDTP=0X3D��CPU T=0
CARDTP=0X3E��CPU T=1
CARDTP=0XFF������ʶ��Ŀ�����
*/

extern	unsigned char	__stdcall	Eject(void);//ǰ�˿�
extern	unsigned char	__stdcall	reject(void);//���˿�

extern	unsigned char	__stdcall	ReadMagCard(unsigned char *track1,unsigned char *track2,unsigned char *track3);
/*
	track1,track2,track3Ϊ����ASCII��ֵ,���ĳһ�ŵ�������ʧ��Ϊ"FFFF"
*/

extern	unsigned char	__stdcall	ICCReSet(unsigned char *ATR,unsigned short *rsplen);//CPU���ϵ�+��λ
/*
	ATR:���ظ�λ��Ϣ,ʮ��������
	rsplen:������Ϣ����
*/

extern	unsigned char	__stdcall	ICCRelease(void);//CPU���µ�
//ic������
extern	unsigned char	__stdcall	ICCISOCommand(unsigned char *command,unsigned short len,unsigned char *RspDat,unsigned short *rsplen);
/*
	command:������,ʮ������
	len:�����
	RspDat:��������
	rsplen:�������ݳ���
*/
extern	unsigned char   __stdcall  IntakeCard(unsigned short timeout);
#endif


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


extern unsigned char	__stdcall	CRTInit(unsigned char port,unsigned char Type);//port为串口号(从0开始),Type为卡机内有卡的处理方式,0保持,1前退卡,2后退卡
extern unsigned char	__stdcall	CardSetting(unsigned char CardIn,unsigned char EnableBackIn);
/*CardIn:设置前端进卡方式
1 	禁止前端进卡
2		磁卡方式进卡使能
3		开关方式进卡使能,允许磁卡, ic卡,m1卡等
4		磁信号方式进卡,针对磁薄卡等一些纸卡进卡
EnableBackIn:设置是否允许后端进卡
0 	允充后端进卡
1		禁止后端进卡
*/
extern	unsigned char	__stdcall	GetCardReaderStatus(unsigned char *atPosition);
/*
	atPosition:	=0x30：卡片在前端不夹卡位置。
				=0x31：卡片在前端夹卡位置。
				=0x32：卡片在读卡机射频卡位置。
				=0x33：卡片在IC卡位置。
				=0x34：卡片在后端夹卡位置。
				=0x35：读卡机内无卡。
				=0x36：卡不在标准位置
*/
extern	unsigned char	__stdcall	CheckICTypeCheckICType(unsigned char *CARDTP);
/*
	rspType:返回值,1字节
	CARDTP=0X30：AT24C01
CARDTP=0X31：AT24C02
CARDTP=0X32：AT24C04
CARDTP=0X33：AT24C08
CARDTP=0X34：AT24C16
CARDTP=0X35：AT24C32
CARDTP=0X36：AT24C64
CARDTP=0X37：AT45DB041
CARDTP=0X38：AT102
CARDTP=0X39：AT1604
CARDTP=0X3A：AT1608
CARDTP=0X3B：SLE4442
CARDTP=0X3C：SLE4428
CARDTP=0X3D：CPU T=0
CARDTP=0X3E：CPU T=1
CARDTP=0XFF：不能识别的卡类型
*/

extern	unsigned char	__stdcall	Eject(void);//前退卡
extern	unsigned char	__stdcall	reject(void);//后退卡

extern	unsigned char	__stdcall	ReadMagCard(unsigned char *track1,unsigned char *track2,unsigned char *track3);
/*
	track1,track2,track3为返回ASCII码值,如果某一磁道读数据失败为"FFFF"
*/

extern	unsigned char	__stdcall	ICCReSet(unsigned char *ATR,unsigned short *rsplen);//CPU卡上电+复位
/*
	ATR:返回复位信息,十六进数据
	rsplen:返回信息长度
*/

extern	unsigned char	__stdcall	ICCRelease(void);//CPU卡下电
//ic卡命令
extern	unsigned char	__stdcall	ICCISOCommand(unsigned char *command,unsigned short len,unsigned char *RspDat,unsigned short *rsplen);
/*
	command:命令字,十六进制
	len:命令长度
	RspDat:返回数据
	rsplen:返回数据长度
*/
extern	unsigned char   __stdcall  IntakeCard(unsigned short timeout);
#endif


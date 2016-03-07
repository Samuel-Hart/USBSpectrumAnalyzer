// TSA_DLL_TEST.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"


int _tmain(int argc, _TCHAR* argv[])
{
	typedef HANDLE(__stdcall *pGet_Hid_Handle)(); 
	typedef bool(__stdcall *pOutput_Serial_Number)(CHAR* DIR_PATH,CHAR* SN);
	typedef BYTE(__stdcall *pStart_Dongle)(HANDLE hDongle,DOUBLE C_FREQ,DWORD STEP,BYTE iRBW,WORD POINTS,BYTE iAMP,BYTE SWEEP_TIME,BYTE EXT_ATT,CHAR* DIR_PATH);
	typedef BYTE(__stdcall *pStop_Dongle)(HANDLE hDongle);
	typedef bool(__stdcall *pReceive_Data_From_Dongle)(HANDLE hDongle,INT &ID,DOUBLE* rev_data,INT &Data_Length);

	HANDLE hDongle;

	HINSTANCE HDLL;   
	HDLL=LoadLibrary("TSA.dll");//LOAD TSA.dll；   
//_________________________________________________________
	pGet_Hid_Handle Get_Hid_Handle=(pGet_Hid_Handle)GetProcAddress(HDLL,"Get_Hid_Handle");
	
	printf("Please insert the dongle!\n");
	
	do
	{
		hDongle=Get_Hid_Handle();
	}while (hDongle==0);

	printf("Dongle is connected!\n");
//-----------------------------------------------
	pOutput_Serial_Number Output_Serial_Number=(pOutput_Serial_Number)GetProcAddress(HDLL,"Output_Serial_Number");

	TCHAR DIR_PATH[MAX_PATH];

	GetCurrentDirectory(MAX_PATH,DIR_PATH);

	CString OFST_PATH;
		
	OFST_PATH.Format(DIR_PATH);

	CHAR SN[10];

	CHAR *pOFST_PATH = (LPSTR)(LPCTSTR)OFST_PATH;

	bool blnResult = Output_Serial_Number(pOFST_PATH,SN);

	CString strSN;

	if (true ==blnResult)
	{strSN.Format("%c%c%c%c%c%c%c%c%c%c",SN[0],SN[1],SN[2],SN[3],SN[4],SN[5],SN[6],SN[7],SN[8],SN[9]);}
	else
	{strSN="NULL";}

	printf("Serial Number is %s\n",strSN);
//-----------------------------------------------
	pStart_Dongle Start_Dongle=(pStart_Dongle)GetProcAddress(HDLL,"Start_Dongle");

	DOUBLE C_FREQ =2800;
	DWORD STEP =10000;
	BYTE iRBW =1;
	WORD POINTS =250;
	BYTE iAMP =6;
	BYTE SWEEP_TIME =0;
	BYTE EXT_ATT=0;

	printf("Center Frequency is %fMHz\n",C_FREQ);
	printf("Step is %dkHz\n",STEP);
	printf("RBW is 50MHz\n");
	printf("Point Number is %d\n",POINTS);
	printf("Amplitude is 0 dBm\n");
	printf("Sweep Time is x1 (CW Mode)\n");
	printf("External Attenuator is unselected\n");

	BYTE bytResult =Start_Dongle(hDongle,C_FREQ,STEP,iRBW,POINTS,iAMP,SWEEP_TIME,EXT_ATT,pOFST_PATH);

	if (0==bytResult) 
	{printf("Start Dongle!\n");}
	else
	{printf("Dongle has a Error!\n");}
//------------------------------------------------------
	pReceive_Data_From_Dongle Receive_Data_From_Dongle=(pReceive_Data_From_Dongle)GetProcAddress(HDLL,"Receive_Data_From_Dongle");

	INT ID;
	DOUBLE* rev_data =new DOUBLE[61];
	INT Data_Length;
	INT count=0;

	do
	{
		blnResult =Receive_Data_From_Dongle(hDongle,ID,rev_data,Data_Length);

		if (true==blnResult) 
		{
			printf("ID:%d\n",ID);
			printf("Data_Length:%d\n",Data_Length);

			for(int i=0;i<Data_Length;i++)
			{printf("%f\t",rev_data[i]);}
			{printf("\n");}
		}
		else
		{printf("Dongle has a Error!\n");}
		count++;
	}while (count!=4);
//------------------------------------------------
	pStop_Dongle Stop_Dongle=(pStop_Dongle)GetProcAddress(HDLL,"Stop_Dongle");
	
	bytResult =Stop_Dongle(hDongle);

	if (0==bytResult) 
	{printf("Stop Dongle!\n");}
	else
	{printf("Dongle has a Error!\n");}

//--------------------------------------------
	system("pause");
	
	FreeLibrary(HDLL);//UNLOAD TSA.dll；  

	return 0;
}


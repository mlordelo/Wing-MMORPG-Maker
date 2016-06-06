//?
#ifndef UNICODE
#define UNICODE 1
#endif

// link with Ws2_32.lib
#pragma comment(lib,"Ws2_32.lib")
#pragma comment(lib, "user32.lib" )
#pragma comment (lib, "advapi32")
#pragma comment(lib, "crypt32.lib")

#include <winsock2.h>
#include <ws2tcpip.h>
#include <stdio.h>
#include <stdlib.h>   // Needed for _wtoi
#include <windows.h>
#include <iostream>
#include <tchar.h>
#include <wincrypt.h>
#include <conio.h>
#include <strsafe.h>

#define KEYLENGTH  0x00800000
#define ENCRYPT_ALGORITHM CALG_RC4 
#define ENCRYPT_BLOCK_SIZE 8 

//<DllImport("advapi32.dll")>

using namespace std;

extern "C"
{
  int __declspec(dllexport) womsocket(int family, int type, int protocol)
  {
	char const *rgss = "RGSS Player";
	char const *wing = "Wing MMORPG Maker RGSS3";

	HWND hwnds = FindWindowA(rgss, wing); 

	if (hwnds == NULL) { return 1; }

	//SOCKET VAR
    SOCKET sock = (family, type, protocol);

	//SOCKET
	sock = socket(family, type, protocol);

	//RETORNAR
	return sock;
  }
  int __declspec(dllexport) womconnect(SOCKET sock, char *ip, int port)
  {
	char const *rgss = "RGSS Player";
	char const *wing = "Wing MMORPG Maker RGSS3";

	HWND hwnds = FindWindowA(rgss, wing); 
    if (hwnds == NULL) { return 1; }
	
	//RESULTADO FINAL
	int iResult = 0;

	//Resolutação DNS
    struct hostent        *he;
    
	//RESOLVER DNS
    if ( (he = gethostbyname(ip) ) == NULL ) {
      return 0; /* error */
    }

    //NOVO ADDR APTO PARA RESOLVER DNS
    sockaddr_in clientService;
	memcpy(&clientService.sin_addr, he->h_addr_list[0], he->h_length);
    clientService.sin_family = AF_INET;
    clientService.sin_port = htons(port);


    //ADDR
    //sockaddr_in clientService;
    //clientService.sin_family = AF_INET;
    //clientService.sin_addr.s_addr = inet_addr(ip);
    //clientService.sin_port = htons(port);

    //CONECTAR
    iResult = connect(sock, (SOCKADDR *) & clientService, sizeof (clientService));
    if (iResult == SOCKET_ERROR) {
        return 1;
    }

	return 0;
  }
  int __declspec(dllexport) womsockopt(SOCKET sock, int protocol, int opt, bool val, int size)
  {
	char const *rgss = "RGSS Player";
	char const *wing = "Wing MMORPG Maker RGSS3";

	HWND hwnds = FindWindowA(rgss, wing); 
    if (hwnds == NULL) { return 1; }

	//RESULTADO FINAL
    int iResult = 0;

	//VALORES
    BOOL bOptVal = val;
    int bOptLen = sizeof (BOOL);

	//ALTERAR CONFIGURAÇÃO
    iResult = setsockopt(sock, protocol, opt, (char *) &bOptVal, bOptLen);

	//RETORNAR PROCESSO
	return iResult;
  }
  int __declspec(dllexport) womtick()
  {
	return GetTickCount();
  }
  int __declspec(dllexport) womsend(SOCKET sock, char *sendbuf, int flags)
  {
	//RESULTADO FINAL
	int iResult = 0;

	//ENVIAR DADOS
	iResult = send(sock, sendbuf, (int)strlen(sendbuf), flags);

	//RETORNAR PROCESSO
	return iResult;
  }
  int __declspec(dllexport) womrecv(SOCKET sock, char *buf, int size, int flags)
  {
	//RESULTADO FINAL
	int iResult = 0;

	//RECEBER DADOS
	iResult = recv(sock, buf, size, flags);

	//RETORNAR PROCESSO
	return iResult;
  }
  int __declspec(dllexport) womclose(SOCKET sock)
  {
	//RESULTADO FINAL
	int iResult = 0;

	//RECEBER DADOS
	iResult = closesocket(sock);

	//RETORNAR PROCESSO
	return iResult;
  }
  u_long __declspec(dllexport) womavailable(SOCKET sock, long opt)
  {
	//RESULTADO FINAL
	int iResult = 0;
	u_long iMode = 0;

	//RECEBER DADOS
	iResult = ioctlsocket(sock, opt, &iMode);

	//RETORNAR PROCESSO
	return iMode;
  }
  HWND __declspec(dllexport) womwindow()
  {
	char const *rgss = "RGSS Player";
	char const *wing = "Wing MMORPG Maker RGSS3";


	//RECEBER DADOS
    HWND hwnds = FindWindowA(rgss, wing); 

	//RETORNAR PROCESSO
	return hwnds;
  }
  int __declspec(dllexport) womshowcursor(bool opt)
  {
	//Alterar cursor
    int iResult = ShowCursor(opt);

	//RETORNAR PROCESSO
	return iResult;
  }

  char __declspec(dllexport) womscreen()
  {
	//string *fullscreen_code = "test"
	  return 0;
	//RETORNAR PROCESSO
	//return *fullscreen_code;
  }
  bool MyEncryptFile(
    LPTSTR szSource, 
    LPTSTR szDestination, 
    LPTSTR szPassword);
  bool MyDecryptFile(
    LPTSTR szSource, 
    LPTSTR szDestination, 
    LPTSTR szPassword);
  char __declspec(dllexport) womencrypt(wchar_t* filedir)
  {
	 TCHAR NPath[MAX_PATH];
     GetCurrentDirectory(MAX_PATH, NPath);

     TCHAR pszSource[260] = _T("");
     StringCchCat(pszSource, 260, NPath);  
     StringCchCat(pszSource, 260, filedir);
	 StringCchCat(pszSource, 260, _T(".png"));

	 TCHAR pszDestination[260] = _T("");
     StringCchCat(pszDestination, 260, NPath);  
     StringCchCat(pszDestination, 260, filedir);
	 StringCchCat(pszDestination, 260, _T(".wing"));

     LPTSTR pszPassword = L"0010WING0101";

	 if(MyEncryptFile(pszSource, pszDestination, pszPassword))
     {
       return 0;
     }
     else
     {
       return 1;
     }

	 return 1;
  }
  char __declspec(dllexport) womdecrypt(wchar_t* filedir)
  {
	 TCHAR NPath[MAX_PATH];
     GetCurrentDirectory(MAX_PATH, NPath);

     TCHAR pszSource[260] = _T("");
     StringCchCat(pszSource, 260, NPath);  
     StringCchCat(pszSource, 260, filedir);
	 StringCchCat(pszSource, 260, _T(".wing"));

	 TCHAR pszDestination[260] = _T("");
     StringCchCat(pszDestination, 260, NPath);  
     StringCchCat(pszDestination, 260, filedir);
	 StringCchCat(pszDestination, 260, _T(".png"));

     LPTSTR pszPassword = L"0010WING0101";

	 if(MyDecryptFile(pszSource, pszDestination, pszPassword))
	 {
		  return 0;
	 }
	 else
	 {
		  return 1;
	 }

	 return 1;
  }
    char __declspec(dllexport) womrvdata2en(wchar_t* filedir)
  {
	 TCHAR NPath[MAX_PATH];
     GetCurrentDirectory(MAX_PATH, NPath);

     TCHAR pszSource[260] = _T("");
     StringCchCat(pszSource, 260, NPath);  
     StringCchCat(pszSource, 260, filedir);
	 StringCchCat(pszSource, 260, _T(".rvdata2"));

	 TCHAR pszDestination[260] = _T("");
     StringCchCat(pszDestination, 260, NPath);  
     StringCchCat(pszDestination, 260, filedir);
	 StringCchCat(pszDestination, 260, _T(".wing"));

     LPTSTR pszPassword = L"0010WING0101";

	 if(MyEncryptFile(pszSource, pszDestination, pszPassword))
     {
       return 0;
     }
     else
     {
       return 1;
     }

	 return 1;
  }
  char __declspec(dllexport) womrvdata2de(wchar_t* filedir)
  {
	 TCHAR NPath[MAX_PATH];
     GetCurrentDirectory(MAX_PATH, NPath);

     TCHAR pszSource[260] = _T("");
     StringCchCat(pszSource, 260, NPath);  
     StringCchCat(pszSource, 260, filedir);
	 StringCchCat(pszSource, 260, _T(".wing"));

	 TCHAR pszDestination[260] = _T("");
     StringCchCat(pszDestination, 260, NPath);  
     StringCchCat(pszDestination, 260, filedir);
	 StringCchCat(pszDestination, 260, _T(".rvdata2"));

     LPTSTR pszPassword = L"0010WING0101";

	 if(MyDecryptFile(pszSource, pszDestination, pszPassword))
	 {
		  return 0;
	 }
	 else
	 {
		  return 1;
	 }

	 return 1;
  }
//-------------------------------------------------------------------
// Code for the function MyDecryptFile called by main.
//-------------------------------------------------------------------
// Parameters passed are:
//  pszSource, the name of the input file, an encrypted file.
//  pszDestination, the name of the output, a plaintext file to be 
//   created.
//  pszPassword, either NULL if a password is not to be used or the 
//   string that is the password.
bool MyDecryptFile(
    LPTSTR pszSourceFile, 
    LPTSTR pszDestinationFile, 
    LPTSTR pszPassword)
{ 
    //---------------------------------------------------------------
    // Declare and initialize local variables.
    bool fReturn = false;
    HANDLE hSourceFile = INVALID_HANDLE_VALUE;
    HANDLE hDestinationFile = INVALID_HANDLE_VALUE; 
    HCRYPTKEY hKey = NULL; 
    HCRYPTHASH hHash = NULL; 

    HCRYPTPROV hCryptProv = NULL; 

    DWORD dwCount;
    PBYTE pbBuffer = NULL; 
    DWORD dwBlockLen; 
    DWORD dwBufferLen; 

    //---------------------------------------------------------------
    // Open the source file. 
    hSourceFile = CreateFile(
        pszSourceFile, 
        FILE_READ_DATA,
        FILE_SHARE_READ,
        NULL,
        OPEN_EXISTING,
        FILE_ATTRIBUTE_NORMAL,
        NULL);
    if(INVALID_HANDLE_VALUE != hSourceFile)
    {

    }
    else
    { 
        goto Exit_MyDecryptFile;
    } 

    //---------------------------------------------------------------
    // Open the destination file. 
    hDestinationFile = CreateFile(
        pszDestinationFile, 
        FILE_WRITE_DATA,
        FILE_SHARE_READ,
        NULL,
        OPEN_ALWAYS,
        FILE_ATTRIBUTE_NORMAL,
        NULL);
    if(INVALID_HANDLE_VALUE != hDestinationFile)
    {

    }
    else
    {
		MessageBox(NULL, TEXT("Erro ao processar memória de destino. Código 20"), TEXT("Erro"), 0);
        goto Exit_MyDecryptFile;
    }

    //---------------------------------------------------------------
    // Get the handle to the default provider. 
    if(CryptAcquireContext(
        &hCryptProv, 
        NULL, 
        MS_ENHANCED_PROV, 
        PROV_RSA_FULL, 
        0))
    {

    }
    else
    {
		if (GetLastError() == NTE_BAD_KEYSET)
		{
			if (!CryptAcquireContext(
				&hCryptProv, 
				NULL, 
				MS_ENHANCED_PROV, 
				PROV_RSA_FULL, 
				CRYPT_NEWKEYSET))
			{
				MessageBox(NULL, TEXT("Erro durante CryptAcquireContext. Código 21"), TEXT("Erro"), 0);
                goto Exit_MyDecryptFile;
			}
		}
    }

    //---------------------------------------------------------------
    // Create the session key.
    if(!pszPassword || !pszPassword[0]) 
    { 
        //-----------------------------------------------------------
        // Decrypt the file with the saved session key. 

        DWORD dwKeyBlobLen;
        PBYTE pbKeyBlob = NULL;

        // Read the key BLOB length from the source file. 
        if(!ReadFile(
            hSourceFile, 
            &dwKeyBlobLen, 
            sizeof(DWORD), 
            &dwCount, 
            NULL))
        {
			MessageBox(NULL, TEXT("Erro durante leitura de memória. Código 22"), TEXT("Erro"), 0);
            goto Exit_MyDecryptFile;
        }

        // Allocate a buffer for the key BLOB.
        if(!(pbKeyBlob = (PBYTE)malloc(dwKeyBlobLen)))
        {

        }

        //-----------------------------------------------------------
        // Read the key BLOB from the source file. 
        if(!ReadFile(
            hSourceFile, 
            pbKeyBlob, 
            dwKeyBlobLen, 
            &dwCount, 
            NULL))
        {
			MessageBox(NULL, TEXT("Erro ao ler memória de origem. Código 23"), TEXT("Erro"), 0);
            goto Exit_MyDecryptFile;
        }

        //-----------------------------------------------------------
        // Import the key BLOB into the CSP. 
        if(!CryptImportKey(
              hCryptProv, 
              pbKeyBlob, 
              dwKeyBlobLen, 
              0, 
              0, 
              &hKey))
        {
			MessageBox(NULL, TEXT("Erro durante CryptImportKey. Código 24"), TEXT("Erro"), 0);
            goto Exit_MyDecryptFile;
        }

        if(pbKeyBlob)
        {
            free(pbKeyBlob);
        }
    }
    else
    {
        //-----------------------------------------------------------
        // Decrypt the file with a session key derived from a 
        // password. 

        //-----------------------------------------------------------
        // Create a hash object. 
        if(!CryptCreateHash(
               hCryptProv, 
               CALG_MD5, 
               0, 
               0, 
               &hHash))
        {
			MessageBox(NULL, TEXT("Erro durante CryptCreateHash. Código 25"), TEXT("Erro"), 0);
            goto Exit_MyDecryptFile;
        }
        
        //-----------------------------------------------------------
        // Hash in the password data. 
        if(!CryptHashData(
               hHash, 
               (BYTE *)pszPassword, 
               lstrlen(pszPassword), 
               0)) 
        {
			MessageBox(NULL, TEXT("Erro durante CryptHashData. Código 26"), TEXT("Erro"), 0);
            goto Exit_MyDecryptFile;
        }
    
        //-----------------------------------------------------------
        // Derive a session key from the hash object. 
        if(!CryptDeriveKey(
              hCryptProv, 
              ENCRYPT_ALGORITHM, 
              hHash, 
              KEYLENGTH, 
              &hKey))
        { 
			MessageBox(NULL, TEXT("Erro durante CryptDeriveKey. Código 27"), TEXT("Erro"), 0);
            goto Exit_MyDecryptFile;
        }
    }

    //---------------------------------------------------------------
    // The decryption key is now available, either having been 
    // imported from a BLOB read in from the source file or having 
    // been created by using the password. This point in the program 
    // is not reached if the decryption key is not available.
     
    //---------------------------------------------------------------
    // Determine the number of bytes to decrypt at a time. 
    // This must be a multiple of ENCRYPT_BLOCK_SIZE. 

    dwBlockLen = 1000 - 1000 % ENCRYPT_BLOCK_SIZE; 
    dwBufferLen = dwBlockLen; 

    //---------------------------------------------------------------
    // Allocate memory for the file read buffer. 
    if(!(pbBuffer = (PBYTE)malloc(dwBufferLen)))
    {
	   MessageBox(NULL, TEXT("Erro ao alocar memória. Código 28"), TEXT("Erro"), 0);
       goto Exit_MyDecryptFile;
    }
    
    //---------------------------------------------------------------
    // Decrypt the source file, and write to the destination file. 
    bool fEOF = false;
    do
    {
        //-----------------------------------------------------------
        // Read up to dwBlockLen bytes from the source file. 
        if(!ReadFile(
            hSourceFile, 
            pbBuffer, 
            dwBlockLen, 
            &dwCount, 
            NULL))
        {
			MessageBox(NULL, TEXT("Erro ao processar memória de origem. Código 29"), TEXT("Erro"), 0);;
            goto Exit_MyDecryptFile;
        }

        if(dwCount < dwBlockLen)
        {
            fEOF = TRUE;
        }

        //-----------------------------------------------------------
        // Decrypt the block of data. 
        if(!CryptDecrypt(
              hKey, 
              0, 
              fEOF, 
              0, 
              pbBuffer, 
              &dwCount))
        {
			MessageBox(NULL, TEXT("Erro durante CryptDecrypt. Código 30"), TEXT("Erro"), 0);
            goto Exit_MyDecryptFile;
        }

        //-----------------------------------------------------------
        // Write the decrypted data to the destination file. 
        if(!WriteFile(
            hDestinationFile, 
            pbBuffer, 
            dwCount,
            &dwCount,
            NULL))
        { 
			MessageBox(NULL, TEXT("Erro ao criar memória virtual. Código 31"), TEXT("Erro"), 0);
            goto Exit_MyDecryptFile;
        }

        //-----------------------------------------------------------
        // End the do loop when the last block of the source file 
        // has been read, encrypted, and written to the destination 
        // file.
    }while(!fEOF);

    fReturn = true;

Exit_MyDecryptFile:

    //---------------------------------------------------------------
    // Free the file read buffer.
    if(pbBuffer)
    {
        free(pbBuffer);
    }

    //---------------------------------------------------------------
    // Close files.
    if(hSourceFile)
    {
        CloseHandle(hSourceFile);
    }

    if(hDestinationFile)
    {
        CloseHandle(hDestinationFile);
    }

    //-----------------------------------------------------------
    // Release the hash object. 
    if(hHash) 
    {
        if(!(CryptDestroyHash(hHash)))
        {
			MessageBox(NULL, TEXT("Erro ao liberar memória. Código 33"), TEXT("Erro"), 0);
        }

        hHash = NULL;
    }

    //---------------------------------------------------------------
    // Release the session key. 
    if(hKey)
    {
        if(!(CryptDestroyKey(hKey)))
        {
			MessageBox(NULL, TEXT("Erro ao liberar memória. Código 32"), TEXT("Erro"), 0);
        }
    } 

    //---------------------------------------------------------------
    // Release the provider handle. 
    if(hCryptProv)
    {
        if(!(CryptReleaseContext(hCryptProv, 0)))
        {
			MessageBox(NULL, TEXT("Erro durante CryptReleaseContext. Código 31"), TEXT("Erro"), 0);
        }
    } 

    return fReturn;
}


//-------------------------------------------------------------------
// Code for the function MyEncryptFile called by main.
//-------------------------------------------------------------------
// Parameters passed are:
//  pszSource, the name of the input, a plaintext file.
//  pszDestination, the name of the output, an encrypted file to be 
//   created.
//  pszPassword, either NULL if a password is not to be used or the 
//   string that is the password.
bool MyEncryptFile(
    LPTSTR pszSourceFile, 
    LPTSTR pszDestinationFile, 
    LPTSTR pszPassword)
{ 
    //---------------------------------------------------------------
    // Declare and initialize local variables.
    bool fReturn = false;
    HANDLE hSourceFile = INVALID_HANDLE_VALUE;
    HANDLE hDestinationFile = INVALID_HANDLE_VALUE; 

    HCRYPTPROV hCryptProv = NULL; 
    HCRYPTKEY hKey = NULL; 
    HCRYPTKEY hXchgKey = NULL; 
    HCRYPTHASH hHash = NULL; 

    PBYTE pbKeyBlob = NULL; 
    DWORD dwKeyBlobLen; 

    PBYTE pbBuffer = NULL; 
    DWORD dwBlockLen; 
    DWORD dwBufferLen; 
    DWORD dwCount; 
     
    //---------------------------------------------------------------
    // Open the source file. 
    hSourceFile = CreateFile(
        pszSourceFile, 
        FILE_READ_DATA,
        FILE_SHARE_READ,
        NULL,
        OPEN_EXISTING,
        FILE_ATTRIBUTE_NORMAL,
        NULL);
    if(INVALID_HANDLE_VALUE != hSourceFile)
    {
    }
    else
    { 
        	MessageBox(NULL, TEXT("Erro ao abrir memória plana. Código: 2"), TEXT("Erro"), 0);
        goto Exit_MyEncryptFile;
    } 

    //---------------------------------------------------------------
    // Open the destination file. 
    hDestinationFile = CreateFile(
        pszDestinationFile, 
        FILE_WRITE_DATA,
        FILE_SHARE_READ,
        NULL,
        OPEN_ALWAYS,
        FILE_ATTRIBUTE_NORMAL,
        NULL);
    if(INVALID_HANDLE_VALUE != hDestinationFile)
    {
    }
    else
    {
        MessageBox(NULL, TEXT("Erro ao encontrar referência de memória. Código: 3"), TEXT("Erro"), 0);
        goto Exit_MyEncryptFile;
    }

    //---------------------------------------------------------------
    // Get the handle to the default provider. 
    if(CryptAcquireContext(
        &hCryptProv, 
        NULL, 
        MS_ENHANCED_PROV, 
        PROV_RSA_FULL, 
        0)) 
    {
    }
    else
    {
		if (GetLastError() == NTE_BAD_KEYSET)
		{
			if (!CryptAcquireContext(
				&hCryptProv, 
				NULL, 
				MS_ENHANCED_PROV, 
				PROV_RSA_FULL, 
				CRYPT_NEWKEYSET))
			{
				MessageBox(NULL, TEXT("Erro durante CryptAcquireContext. Código 4"), TEXT("Erro"), 0);
				goto Exit_MyEncryptFile;
			}
		}
    }

    //---------------------------------------------------------------
    // Create the session key.
    if(!pszPassword || !pszPassword[0]) 
    { 
        //-----------------------------------------------------------
        // No password was passed.
        // Encrypt the file with a random session key, and write the 
        // key to a file. 

        //-----------------------------------------------------------
        // Create a random session key. 
        if(CryptGenKey(
            hCryptProv, 
            ENCRYPT_ALGORITHM, 
            KEYLENGTH | CRYPT_EXPORTABLE, 
            &hKey))
        {

        } 
        else
        {
            	MessageBox(NULL, TEXT("Erro durante CryptGenKey: Código 5"), TEXT("Erro"), 0);
            goto Exit_MyEncryptFile;
        }

        //-----------------------------------------------------------
        // Get the handle to the exchange public key. 
        if(CryptGetUserKey(
            hCryptProv, 
            AT_KEYEXCHANGE, 
            &hXchgKey))
        {

        }
        else
        { 
            if(NTE_NO_KEY == GetLastError())
            {
                // No exchange key exists. Try to create one.
                if(!CryptGenKey(
                    hCryptProv, 
                    AT_KEYEXCHANGE, 
                    CRYPT_EXPORTABLE, 
                    &hXchgKey))
                {
                    	MessageBox(NULL, TEXT("Falha ao criar chave virtual. Código 6"), TEXT("Erro"), 0);
                    goto Exit_MyEncryptFile;
                }
            }
            else
            {
                	MessageBox(NULL, TEXT("Chave virtual indisponível. Código 6.1"), TEXT("Erro"), 0);
                goto Exit_MyEncryptFile;
            }
        }

        //-----------------------------------------------------------
        // Determine size of the key BLOB, and allocate memory. 
        if(CryptExportKey(
            hKey, 
            hXchgKey, 
            SIMPLEBLOB, 
            0, 
            NULL, 
            &dwKeyBlobLen))
        {
        }
        else
        {  
            	MessageBox(NULL, TEXT("Erro ao computar distância Blob ;D. Código 7"), TEXT("Erro"), 0);
            goto Exit_MyEncryptFile;
        }

        if(pbKeyBlob = (BYTE *)malloc(dwKeyBlobLen))
        { 

        }
        else
        { 
           	MessageBox(NULL, TEXT("Falta de memória para execução. Código 7.1"), TEXT("Erro"), 0); 
            goto Exit_MyEncryptFile;
        }

        //-----------------------------------------------------------
        // Encrypt and export the session key into a simple key 
        // BLOB. 
        if(CryptExportKey(
            hKey, 
            hXchgKey, 
            SIMPLEBLOB, 
            0, 
            pbKeyBlob, 
            &dwKeyBlobLen))
        {
        } 
        else
        {
            MessageBox(NULL, TEXT("Erro durante CryptExportKey. Código 8"), TEXT("Erro"), 0);
            goto Exit_MyEncryptFile;
        } 
         
        //-----------------------------------------------------------
        // Release the key exchange key handle. 
        if(hXchgKey)
        {
            if(!(CryptDestroyKey(hXchgKey)))
            {
                MessageBox(NULL, TEXT("Falha ao liberar espaço. Código 9"), TEXT("Erro"), 0); 
                goto Exit_MyEncryptFile;
            }
      
            hXchgKey = 0;
        }
     
        //-----------------------------------------------------------
        // Write the size of the key BLOB to the destination file. 
        if(!WriteFile(
            hDestinationFile, 
            &dwKeyBlobLen, 
            sizeof(DWORD),
            &dwCount,
            NULL))
        { 
           	MessageBox(NULL, TEXT("Falha ao tentar criar memória. Código: 1"), TEXT("Erro"), 0);
            goto Exit_MyEncryptFile;
        }
        else
        {
        }

        //-----------------------------------------------------------
        // Write the key BLOB to the destination file. 
        if(!WriteFile(
            hDestinationFile, 
            pbKeyBlob, 
            dwKeyBlobLen,
            &dwCount,
            NULL))
        { 
           	MessageBox(NULL, TEXT("Falha ao tentar criar memória. Código: 1.1"), TEXT("Erro"), 0);
            goto Exit_MyEncryptFile;
        }
        else
        {
            
        }

        // Free memory.
        free(pbKeyBlob);
    } 
    else 
    { 

        //-----------------------------------------------------------
        // The file will be encrypted with a session key derived 
        // from a password.
        // The session key will be recreated when the file is 
        // decrypted only if the password used to create the key is 
        // available. 

        //-----------------------------------------------------------
        // Create a hash object. 
        if(CryptCreateHash(
            hCryptProv, 
            CALG_MD5, 
            0, 
            0, 
            &hHash))
        {

        }
        else
        { 
            MessageBox(NULL, TEXT("Erro durante CryptCreateHash. Código 10"), TEXT("Erro"), 0);
            goto Exit_MyEncryptFile;
        }  

        //-----------------------------------------------------------
        // Hash the password. 
        if(CryptHashData(
            hHash, 
            (BYTE *)pszPassword, 
            lstrlen(pszPassword), 
            0))
        {

        }
        else
        {
            MessageBox(NULL, TEXT("Erro durante CryptHashData. Código 11"), TEXT("Erro"), 0);
        }

        //-----------------------------------------------------------
        // Derive a session key from the hash object. 
        if(CryptDeriveKey(
            hCryptProv, 
            ENCRYPT_ALGORITHM, 
            hHash, 
            KEYLENGTH, 
            &hKey))
        {
            
        }
        else
        {
            MessageBox(NULL, TEXT("Erro durante CryptDeriveKey. Código 12"), TEXT("Erro"), 0);
            goto Exit_MyEncryptFile;
        }
    } 

    //---------------------------------------------------------------
    // The session key is now ready. If it is not a key derived from 
    // a  password, the session key encrypted with the private key 
    // has been written to the destination file.
     
    //---------------------------------------------------------------
    // Determine the number of bytes to encrypt at a time. 
    // This must be a multiple of ENCRYPT_BLOCK_SIZE.
    // ENCRYPT_BLOCK_SIZE is set by a #define statement.
    dwBlockLen = 1000 - 1000 % ENCRYPT_BLOCK_SIZE; 

    //---------------------------------------------------------------
    // Determine the block size. If a block cipher is used, 
    // it must have room for an extra block. 
    if(ENCRYPT_BLOCK_SIZE > 1) 
    {
        dwBufferLen = dwBlockLen + ENCRYPT_BLOCK_SIZE; 
    }
    else 
    {
        dwBufferLen = dwBlockLen; 
    }
        
    //---------------------------------------------------------------
    // Allocate memory. 
    if(pbBuffer = (BYTE *)malloc(dwBufferLen))
    {
    }
    else
    { 
        MessageBox(NULL, TEXT("Falta de memória, impossível continuar. Código 13"), TEXT("Erro"), 0);
        goto Exit_MyEncryptFile;
    }

    //---------------------------------------------------------------
    // In a do loop, encrypt the source file, 
    // and write to the source file. 
    bool fEOF = FALSE;
    do 
    { 
        //-----------------------------------------------------------
        // Read up to dwBlockLen bytes from the source file. 
        if(!ReadFile(
            hSourceFile, 
            pbBuffer, 
            dwBlockLen, 
            &dwCount, 
            NULL))
        {
           MessageBox(NULL, TEXT("Erro ao ler processar memória plana. Código 14"), TEXT("Erro"), 0);
        }

        if(dwCount < dwBlockLen)
        {
			fEOF = TRUE;
        }

        //-----------------------------------------------------------
        // Encrypt data. 
        if(!CryptEncrypt(
            hKey, 
            NULL, 
            fEOF,
            0, 
            pbBuffer, 
            &dwCount, 
            dwBufferLen))
        { 
            MessageBox(NULL, TEXT("Erro durante CryptEncrypt. Código 15"), TEXT("Erro"), 0);
            goto Exit_MyEncryptFile;
        } 

        //-----------------------------------------------------------
        // Write the encrypted data to the destination file. 
        if(!WriteFile(
            hDestinationFile, 
            pbBuffer, 
            dwCount,
            &dwCount,
            NULL))
        { 
            MessageBox(NULL, TEXT("Erro ao criar CipherText. Código 16"), TEXT("Erro"), 0);
            goto Exit_MyEncryptFile;
        }

        //-----------------------------------------------------------
        // End the do loop when the last block of the source file 
        // has been read, encrypted, and written to the destination 
        // file.
    } while(!fEOF);

    fReturn = true;

Exit_MyEncryptFile:
    //---------------------------------------------------------------
    // Close files.
    if(hSourceFile)
    {
        CloseHandle(hSourceFile);
    }

    if(hDestinationFile)
    {
        CloseHandle(hDestinationFile);
    }

    //---------------------------------------------------------------
    // Free memory. 
    if(pbBuffer) 
    {
        free(pbBuffer); 
    }
     

    //-----------------------------------------------------------
    // Release the hash object. 
    if(hHash) 
    {
        if(!(CryptDestroyHash(hHash)))
        {
            	MessageBox(NULL, TEXT("Erro durante CryptDestroyHash. Código 17"), TEXT("Erro"), 0);
        }

        hHash = NULL;
    }

    //---------------------------------------------------------------
    // Release the session key. 
    if(hKey)
    {
        if(!(CryptDestroyKey(hKey)))
        {
	       MessageBox(NULL, TEXT("Erro durante CryptDestroyKey. Código 18"), TEXT("Erro"), 0);
        }
    }

    //---------------------------------------------------------------
    // Release the provider handle. 
    if(hCryptProv)
    {
        if(!(CryptReleaseContext(hCryptProv, 0)))
        {
		    MessageBox(NULL, TEXT("Erro durante CryptReleaseContext. Código 19"), TEXT("Erro"), 0);
        }
    }
    
    return fReturn; 
} // End Encryptfile.

}

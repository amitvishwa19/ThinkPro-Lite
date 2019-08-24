Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Public Class Encryption
    Private enc As System.Text.UTF8Encoding
    Private encryptor As ICryptoTransform
    Private decryptor As ICryptoTransform
    Public encr, dycr As String

    Public Sub New()
        Dim KEY_128 As Byte() = {42, 1, 52, 67, 231, 13, 94, 101, 123, 6, 0, 12, 32, 91, 4, 111, 31, 70, 21, 141, 123, 142, 234, 82, 95, 129, 187, 162, 12, 55, 98, 23}
        Dim IV_128 As Byte() = {234, 12, 52, 44, 214, 222, 200, 109, 2, 98, 45, 76, 88, 53, 23, 78}
        Dim symmetricKey As RijndaelManaged
        symmetricKey = New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC

        Me.enc = New System.Text.UTF8Encoding
        Me.encryptor = symmetricKey.CreateEncryptor(KEY_128, IV_128)
        Me.decryptor = symmetricKey.CreateDecryptor(KEY_128, IV_128)
    End Sub

    Sub Encrypt(myIiput As String)

        Dim sPlainText As String = String.Empty
        If myIiput.Trim().Length > 0 Then
            sPlainText = myIiput
        End If


        If Not String.IsNullOrEmpty(sPlainText) Then
            Dim memoryStream As MemoryStream = New MemoryStream()
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, Me.encryptor, CryptoStreamMode.Write)
            cryptoStream.Write(Me.enc.GetBytes(sPlainText), 0, sPlainText.Length)
            cryptoStream.FlushFinalBlock()
            encr = Convert.ToBase64String(memoryStream.ToArray())
            memoryStream.Close()
            cryptoStream.Close()
        End If

    End Sub

    Function EncryptNew(myIiput As String)

        Dim sPlainText As String = Nothing
        If myIiput.Trim().Length > 0 Then
            sPlainText = myIiput
        End If
        Dim memoryStream As MemoryStream = New MemoryStream()
        Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, Me.encryptor, CryptoStreamMode.Write)
        cryptoStream.Write(Me.enc.GetBytes(sPlainText), 0, sPlainText.Length)
        cryptoStream.FlushFinalBlock()
        encr = Convert.ToBase64String(memoryStream.ToArray())
        memoryStream.Close()
        cryptoStream.Close()
        Return Convert.ToBase64String(memoryStream.ToArray())

    End Function

    Function decrypt(input As String)

        Try
            Dim cypherTextBytes As Byte() = Convert.FromBase64String(input)
            Dim memoryStream As MemoryStream = New MemoryStream(cypherTextBytes)
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, Me.decryptor, CryptoStreamMode.Read)
            Dim plainTextBytes(cypherTextBytes.Length) As Byte
            Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
            memoryStream.Close()
            cryptoStream.Close()
            Return Me.enc.GetString(plainTextBytes, 0, decryptedByteCount)
        Catch ex As Exception

            Return input
        End Try


    End Function

    Function CheckEncryprion(input As String)

        Try
            Dim cypherTextBytes As Byte() = Convert.FromBase64String(input)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

End Class

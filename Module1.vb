Module Module1
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal ClassName As String, ByVal WindowName As String) As IntPtr
    Public Structure WindowInfo

    End Structure
    '    typedef struct tagWINDOWINFO {
    '  DWORD cbSize;
    '  RECT  rcWindow;
    '  RECT  rcClient;
    '  DWORD dwStyle;
    '  DWORD dwExStyle;
    '  DWORD dwWindowStatus;
    '  UINT  cxWindowBorders;
    '  UINT  cyWindowBorders;
    '  ATOM  atomWindowType;
    '  WORD  wCreatorVersion;
    '} WINDOWINFO, *PWINDOWINFO, *LPWINDOWINFO;
    Sub Main()
        Dim hwnd As IntPtr
        hwnd = System.Diagnostics.Process.GetProcessById(5432).Handle
        Dim pWindowInfo As tagWINDOWINFO
        Dim b As Boolean = NativeMethods.GetWindowInfo(hwnd, pWindowInfo)
        Dim lpTitle As New Text.StringBuilder
        Dim textWd As Integer = NativeMethods.GetWindowTextA(hwnd, lpTitle, 1000)
        Console.WriteLine(hwnd)
        Console.WriteLine(b)
        Console.WriteLine(textWd)
        Console.WriteLine(lpTitle)
        Console.ReadLine()
    End Sub

End Module

<System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)>
Public Structure HWND__

    '''int
    Public unused As Integer
End Structure

<System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)>
Public Structure tagWINDOWINFO

    '''DWORD->unsigned int
    Public cbSize As UInteger

    '''RECT->tagRECT
    Public rcWindow As tagRECT

    '''RECT->tagRECT
    Public rcClient As tagRECT

    '''DWORD->unsigned int
    Public dwStyle As UInteger

    '''DWORD->unsigned int
    Public dwExStyle As UInteger

    '''DWORD->unsigned int
    Public dwWindowStatus As UInteger

    '''UINT->unsigned int
    Public cxWindowBorders As UInteger

    '''UINT->unsigned int
    Public cyWindowBorders As UInteger

    '''ATOM->WORD->unsigned short
    Public atomWindowType As UShort

    '''WORD->unsigned short
    Public wCreatorVersion As UShort
End Structure

<System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)>
Public Structure tagRECT

    '''LONG->int
    Public left As Integer

    '''LONG->int
    Public top As Integer

    '''LONG->int
    Public right As Integer

    '''LONG->int
    Public bottom As Integer
End Structure

Partial Public Class NativeMethods

    '''Return Type: BOOL->int
    '''hwnd: HWND->HWND__*
    '''pwi: PWINDOWINFO->tagWINDOWINFO*
    <System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint:="GetWindowInfo")>
    Public Shared Function GetWindowInfo(<System.Runtime.InteropServices.InAttribute()> ByVal hwnd As System.IntPtr, ByRef pwi As tagWINDOWINFO) As <System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)> Boolean
    End Function
    Public Shared Function GetWindowTextA(<System.Runtime.InteropServices.InAttribute()> ByVal hWnd As System.IntPtr, <System.Runtime.InteropServices.OutAttribute(), System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)> ByVal lpString As System.Text.StringBuilder, ByVal nMaxCount As Integer) As Integer
    End Function

End Class


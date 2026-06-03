Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Threading
Imports System.Media
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection
Imports System.IO.Ports

Public Class FrmMain

    Private FLagALarm As Boolean
    Private NowLhTarget As String
    Private NowRhTarget As String
    Private nowSeq() As String
    Private nowALc1() As String
    Private nowALc2() As String
    Private nowALc3() As String
    Private nowALc4() As String
    Private nowALc5() As String
    Private nowALc6() As String
    Private nowALc7() As String
    Private nowALc8() As String
    Private nowALcDec1() As String
    Private nowALcDec2() As String
    Private nowALcDec3() As String
    Private nowALcDec4() As String
    Private nowALcDec5() As String
    Private nowALcDec6() As String
    Private nowALcDec7() As String
    Private nowALcDec8() As String
    Private Player As New SoundPlayer
    Private TmpTcodeLH As String = ""
    Private TmpPCodeLH As String = ""
    Private TMpScandataLH As String = ""
    Private TmpTcodeRH As String = ""
    Private TmpPCodeRH As String = ""
    Private TMpScandataRH As String = ""

    Private Sub NG()

        Me.Player.SoundLocation = System.AppDomain.CurrentDomain.BaseDirectory & "\SOUND\NG.wav"
        Me.Player.Play()

    End Sub

    Private Sub DingDOng()

        Me.Player.SoundLocation = System.AppDomain.CurrentDomain.BaseDirectory & "\SOUND\DINGDONG.wav"
        Me.Player.Play()

    End Sub

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadPortData()
        SerialOpen()
        FLagALarm = False
        Timer1.Interval = 1000
        Timer1.Start()

        InitGrid()
        LoadData()
        ShowGrid()

    End Sub

    Sub BarcodePrint()

        Dim BigNumSize As String = ""
        Dim TmpBarcodeString As String
        If OkNumber.Length = 1 Then
            BigNumSize = "810"
        ElseIf OkNumber.Length = 2 Then
            BigNumSize = "730"
        End If

        TmpBarcodeString = "CT~~CD,~CC^~CT~" &
        "^XA" &
        "~TA000" &
        "~JSN" &
        "^LT0" &
        "^MNW" &
        "^MTT" &
        "^PON" &
        "^PMN" &
        "^LH0,0" &
        "^JMA" &
        "^PR6,6" &
        "~SD15" &
        "^JUS" &
        "^LRN" &
        "^CI27" &
        "^PA0,1,1,0" &
        "^XZ" &
        "^XA" &
        "^MMT" &
        "^PW1181" &
        "^LL945" &
        "^LS0" &
        "^FO25,25^GB1129,903,5^FS" &
        "^FO27,132^GB1122,0,5^FS" &
        "^FO707,136^GB0,788,5^FS" &
        "^FO25,857^GB682,0,5^FS" &
        "^FO139,25^GB0,832,5^FS" &
        "^FO140,202^GB568,0,5^FS" &
        "^FO288,132^GB0,71,5^FS" &
        "^FO708,366^GB442,0,5^FS" &
        "^FO926,136^GB0,235,5^FS" &
        "^FO711,250^GB438,0,5^FS" &
        "^FO953,141^GE175,104,7^FS" &
        "^FO751,258^GE133,105,3^FS" &
        " ^ FO" & "120" & "," & "135" & "^A0N," & "45" & "," & "45" & "^FD" & CarType & "^FS" &
        "^FO" & "360" & "," & "160" & "^A0N," & "45" & "," & "45" & "^FD" & LotNo & "^FS" &
        "^FO" & "310" & "," & "880" & "^A0N," & "40" & "," & "40" & "^FD" & DeliveryDate & "^FS" &
        "^FO" & BigNumSize & "," & "460" & "^A0N," & "500" & "," & "400" & "^FD" & OkNumber & "^FS" &
        "^FO" & "605" & "," & "210" & "^A0N," & "60" & "," & "60" & "^FD" & "1" & "^FS" &
        "^FO" & "605" & "," & "300" & "^A0N," & "60" & "," & "60" & "^FD" & "2" & "^FS" &
        "^FO" & "605" & "," & "385" & "^A0N," & "60" & "," & "60" & "^FD" & "3" & "^FS" &
        "^FO" & "605" & "," & "470" & "^A0N," & "60" & "," & "60" & "^FD" & "4" & "^FS" &
        "^FO" & "605" & "," & "558" & "^A0N," & "60" & "," & "60" & "^FD" & "5" & "^FS" &
        "^FO" & "605" & "," & "643" & "^A0N," & "60" & "," & "60" & "^FD" & "6" & "^FS" &
        "^FO" & "605" & "," & "725" & "^A0N," & "60" & "," & "60" & "^FD" & "7" & "^FS" &
        "^FO" & "605" & "," & "805" & "^A0N," & "60" & "," & "60" & "^FD" & "8" & "^FS" &
        "^FO" & "200" & "," & "210" & "^A0N," & "60" & "," & "60" & "^FD" & SeqPart(0) & "^FS" &
        "^FO" & "200" & "," & "300" & "^A0N," & "60" & "," & "60" & "^FD" & SeqPart(1) & "^FS" &
        "^FO" & "200" & "," & "385" & "^A0N," & "60" & "," & "60" & "^FD" & SeqPart(2) & "^FS" &
        "^FO" & "200" & "," & "470" & "^A0N," & "60" & "," & "60" & "^FD" & SeqPart(3) & "^FS" &
        "^FO" & "200" & "," & "558" & "^A0N," & "60" & "," & "60" & "^FD" & SeqPart(4) & "^FS" &
        "^FO" & "200" & "," & "643" & "^A0N," & "60" & "," & "60" & "^FD" & SeqPart(5) & "^FS" &
        "^FO" & "200" & "," & "725" & "^A0N," & "60" & "," & "60" & "^FD" & SeqPart(6) & "^FS" &
        "^FO" & "200" & "," & "805" & "^A0N," & "60" & "," & "60" & "^FD" & SeqPart(7) & "^FS" &
        "^FO28,26^GFA,405,1728,16,:Z64:eJzt00tuxCAMBmBHrsSmErPsoioXqcTNCkfLUTgCSxYI1+YRSKKqXVfjReRPimbwjwPwrP9XG/neKZJWU+KemiOApSwvNXPrVhfuVlM3Dnu8uP2IGt6v1uQPJ2QX+JRDVQMFneB12gWT4AXATEcZZdh221/sLv6aljSgXJyns2Q47OS87DQtHa7mjDGOeTiPwF33JuYD6NDMMaDE0y35cp483r7m76f5Xc4QrO9OMloANxxk9Ahu3G+/7zK8yzNPB7navOVlH8AV7E5WwrAFU7eWMExRcbUiOXiq85SzUYyLqS7k4e1mfzLcvD9Odvtb281jP97bLh739wH1EMPReHV2MItNMjXkn6yzofn93K2KaSGuDtNIul7KNJL8fXUrG2+f8LP+VN9GVWH+:4051" &
        "^FO50,472^GFA,425,1620,12,:Z64:eJzV0rFOxDAMAFBbHXJbfwBxfEhEvoU/YOyAaNH9FkNv6m+EL7jeFqQTJmli1z1oBwak8/RUuY7jGOBfo4FXsGykLvsFmop6sSG6sOujMqx5tD/twvyvC3NNFyplZH/F3trSTzLkPpEmT4GnrgGX86uhF5vBi+vDKHYYpM4jPMv3O3gQ79JMiuHaPKmtnDXfXKDn3djT2fNuJPNuJBvys4/lrRv0dacsu4H0qy/RHb87EtdBwlg/uzq9xXPzWWb4iP2UHg6fHtrcp4Oz5+7v4Um8S3ex6vUs7xL5hct7rXmaibbUvPJa/ppvLxowvNo27XknbqkXp9nFqKMxVKN4xNke1Hdlla/rcP1anbu0C2CNeE9E27aNmKzcq6b3uWYyn5tc+gHVJ6i7bFrl6zqLuck89Zz/Ht+w9h/b:2137" &
        "^FO422,42^GFA,861,4536,56,:Z64:eJztl8mRrDAMhqE4cCQEQnFo7tAIhRB85EChp1/yIkyzzbu2qmHA9tfW7p6m+clPfvJc+vVikj71g4gLl5yfsLzDDZcjCI+3uN9yjkLF9URT4jpKozVHtFbcSPxVd1wnozuOH5YTjk2gWThWiu87zkOFO24gWLPjKIzbLTduLc05Di3h+vR0y7ml8aFwG5biI5zHME+zj5eaC/gkrtvkwpbgZB8PpFsrzs/NuOy4foN/wWF3fl6b9Ch2aBz81AwVh3hKVPHGS5V+wYmunXpFTD3h/FRxsGxAnDD3hJPQY4LDunKc+M8jTvcbEQFaPNQd5xfcjOIITpI9POIkDm5G9k0DFB1qzsQvcjl+bBOnvVxqq+Fsvign+aLemdhBeMt1ZTiTn5HL+cmcY4ThcOBsPaQYffotWsm1P6EBzDFB21iftv4Sh/pbEzeQpMykOWe4Uu+FS/aAW+JEzeX+4rVCYXLsS1jUyxd2n1gQhcv9rHDcz+bEZdEXw6X+WbhB9L/j+tivCycVd8VN9nwoXDofJAFUthNOd08cpObU5V+4o1xzg93l/7lzPcMph7w54zgnDpyXDmQ5iAvJ5cotNTeStsq3HJG2vGdcHpSjJ7znUFFyFmgKnHFrlWeq8HbNRfN39qElxLPgFefQ2S0X68GVzvmdC/FH0EuOOzB62Z84tSLG4a9cdIVy0UmGW9Jr0fMVZ/zyjitxiJz2YeXM70pr3/wl7g+5Q57tuKzWgZO8XiyH8/aeM3UUudFwer5/42T5tOOC4eamyJ4bcp+I3GA4V3NGUl9Koja53AOeiv1fwH9Olx2kMxydLztIu317fCBlE7v1vRSj+uVi2U/+AWX+VgI=:28A8" &
        "^FO152,146^GFA,253,900,20,:Z64:eJzV0UsOwiAQBuCZYMJOj9CLkHAtNxqO1qPMEVhiov3lVVraxpUunIQAXwjDDET/GCx1Yeqgi2NRQCDr9oZxZwxvFKbO1MbSrCX0ZrTT7ro2zBY3Hy3lOLSYoxke7S1b42JWsr1KD1JtKxsAkI21DqOV2qtsKbZm8SQrZu5qs1s1H+tlT9muvhkDPlsIxYBiscfK33uL57TYnanxvJhQNqbTkqPa/G/NTPv39X3TV6yPI/tJvAHIY9Qj:8D41" &
        "^FO985,160^GFA,261,1056,16,:Z64:eJzV0sENwyAMAEAjHnkyAqNkNMhmGYURWvWD1MiujSEiaSXSV1W/fKA4NgDw74GnDMHkN1siHHgrdkR0Hxu0Qu/nR0uUfqaH2lIsdtWesjppP4E2Q7zgq7le8bwWm+YQ1QhhEZPOazPMYl5v9gtvW5xo32e7rC7fy+9u1VJfyic1qA2t1dJfhona+Wr/Hpt1Ppe7m5HzTYebAhNbxnO3++ot54iXzMkF7+9h6HR8P0N/W3/gLs7+RbwA7833Zg==:E084" &
        "^FO779,269^GFA,189,420,12,:Z64:eJy10EEKwjAQBdCRAWdnL1DoNboyV/IG5mj1JjlCdmahfv9kChURF4KBkEcI/w8R+e8a0BRN7JvlyD3LkHnssLhToafrzX1v7ovb6pk+8JIuKSomQG1PJDzoyHxzb4QXjPLZyD5PX4qiPh4bxVA3y0nz/OqIsFw39/fhyFlr1vzxhz98AlSaUE0=:A08F" &
        "^FO777,307^GFA,201,444,12,:Z64:eJy1zrENwjAQBdBvuXAHC5zEGq5gJTYA74HEGpSOsgYF2cJFxOdytgxFhETBFdaTdf7+wJ/nKIDLQKzeu3x6qg+8g6nbcej249T2IT5NWaLazeLPzYFvb3np3oTrmD6sOaTt7AbNN+vb5V/yppnF+vRu1hO1mzqwVMcVLxPb4TnDosu667bo+0fQq6/+ZV6j1mYL:0AA7" &
        "^FO952,285^GFA,381,1416,24,:Z64:eJzt0k1OxCAUAOBHWLB83oCbDNdy0UzxBHOEuQpHYU5g3WGCPPkvHTEaF8aFbFq+tPD+AP7XV8vVJ+qJL8nR1FcQRPpbjtvgzMWNIno2oHxzOPga5h73S45GHZzFc4ufDs6dMsXPzVNmhm/4wVeLRlhR/Y2qM/LZbXb22lxQiG74vSPR4Pxl8Mvu4tZdywv186Up8ayueYlH6ejcJ4/nUI9/hcGRuJPZWUguQvQUJ7X6CN8959XqKV1yzBtlsNcfbfZr+hmfhn7lTstrvGzNfan95aU3aJvXeQBJMd+z2KYeuJs59ywkt2l+9O7CgV/2Id2/3+Ax9YvI9OGVMX5m4WHmoAGmDj/xUpVPnSj0fH/L/+56B9ZgPf4=:8140" &
        "^FO748,160^GFA,353,1340,20,:Z64:eJzl0zFuxSAMBmAjBsYcgd6Eq/QIvQF5U69Fp14jb+rKm4pUxF9jXlWHZH1SpVoREl8Q2CYh+j9hynE2xqUeDUh9aH0Whlkgz+aAMtsC1G5VmS+uzRaSQT9vZyvFg8lDtiiLsvTUXD6xT+ytp/khtuoz/M5GLuFdmU+m9S1etUltBNn9bqMHtolFLjT/9MpVbQbY+g7aKIJTDlkM27B+R4bXaiO5lNSN4fd+e1t5Zr+KuvN2YkXM3aTbHhyNnuXNsjVlI/wGZZw5lxNSvMwW13CdDeRv8g1lO6pG4SyX62TcMPemTPpSyR7shegy29P929VGjzWp7bE2/bF/J74Bbdo27Q==:1BFA" &
        "^FO255,860^GB0,68,5^FS" &
        "^FO662,876^GFA,97,164,4,:Z64:eJxjYCAEmA/A8R/mA8z/mQ+w/28+wN9++AA/4+MDckgYxAeJs/8/DFTXfIDxH1BPBSqu//8biP+DMYrZcIwJAKmZLfM=:AF40" &
        "^FT59,907^A0N,34,53^FH\^CI28^FDLot No.^FS^CI27" &
        "^PQ1,,,Y" &
        "^XZ"

        SerialPrinter.Write(TmpBArcodeSTring)

        TmpBarcodeString = "CT~~CD,~CC^~CT~" &
                            "^XA" &
                            "~TA000" &
                            "~JSN" &
                            "^LT0" &
                            "^MNW" &
                            "^MTT" &
                            "^PON" &
                            "^PMN" &
                            "^LH0,0" &
                            "^JMA" &
                            "^PR6,6" &
                            "~SD15" &
                            "^JUS" &
                            "^LRN" &
                            "^CI27" &
                            "^PA0,1,1,0" &
                            "^XZ" &
                            "^XA" &
                            "^MMT" &
                            "^PW1181" &
                            "^LL945" &
                            "^LS0" &
                            "^FT167,97^A0N,42,43^FH\^CI28^FDALC^FS^CI27" &
                            "^FO17,28^GB93,112,5^FS" &
                            "^FO105,28^GB215,112,5^FS" &
                            "^FO317,86^GB215,54,5^FS" &
                            "^FO527,86^GB215,54,5^FS" &
                            "^FO737,86^GB215,54,5^FS" &
                            "^FO947,86^GB215,54,5^FS" &
                            "^FO317,28^GB425,64,5^FS" &
                            "^FO737,28^GB425,64,5^FS" &
                            "^FT490,71^A0N,42,43^FH\^CI28^FDLH^FS^CI27" &
                            "^FT913,70^A0N,42,43^FH\^CI28^FDRH^FS^CI27" &
                            "^FT359,125^A0N,33,33^FH\^CI28^FDPart No.^FS^CI27" &
                            "^FT782,125^A0N,33,33^FH\^CI28^FDPart No.^FS^CI27" &
                            "^FT571,125^A0N,33,33^FH\^CI28^FDLot No.^FS^CI27" &
                            "^FT997,125^A0N,33,33^FH\^CI28^FDLot No.^FS^CI27" &
                            "^FO17,134^GB93,101,5^FS" &
                            "^FO17,231^GB93,101,5^FS" &
                            "^FO17,328^GB93,101,5^FS" &
                            "^FO17,426^GB93,101,5^FS" &
                            "^FO17,522^GB93,101,5^FS" &
                            "^FO17,619^GB93,101,5^FS" &
                            "^FO17,715^GB93,101,5^FS" &
                            "^FO17,812^GB93,101,5^FS" &
                            "^FO105,134^GB215,101,5^FS" &
                            "^FO105,231^GB215,101,5^FS" &
                            "^FO105,328^GB215,101,5^FS" &
                            "^FO105,426^GB215,101,5^FS" &
                            "^FO105,522^GB215,101,5^FS" &
                            "^FO105,618^GB215,101,5^FS" &
                            "^FO105,714^GB215,101,5^FS" &
                            "^FO105,811^GB215,101,5^FS" &
                            "^FO317,134^GB215,101,5^FS" &
                            "^FO527,134^GB215,101,5^FS" &
                            "^FO737,134^GB215,101,5^FS" &
                            "^FO947,134^GB215,101,5^FS" &
                            "^FO317,231^GB215,101,5^FS" &
                            "^FO527,231^GB215,101,5^FS" &
                            "^FO737,231^GB215,101,5^FS" &
                            "^FO947,231^GB215,101,5^FS" &
                            "^FO317,328^GB215,101,5^FS" &
                            "^FO527,328^GB215,101,5^FS" &
                            "^FO737,328^GB215,101,5^FS" &
                            "^FO947,328^GB215,101,5^FS" &
                            "^FO317,426^GB215,101,5^FS" &
                            "^FO527,426^GB215,101,5^FS" &
                            "^FO737,426^GB215,101,5^FS" &
                            "^FO947,426^GB215,101,5^FS" &
                            "^FO317,522^GB215,101,5^FS" &
                            "^FO527,522^GB215,101,5^FS" &
                            "^FO737,522^GB215,101,5^FS" &
                            "^FO947,522^GB215,101,5^FS" &
                            "^FO317,619^GB215,101,5^FS" &
                            "^FO527,619^GB215,101,5^FS" &
                            "^FO737,619^GB215,101,5^FS" &
                            "^FO947,619^GB215,101,5^FS" &
                            "^FO317,714^GB215,101,5^FS" &
                            "^FO527,714^GB215,101,5^FS" &
                            "^FO737,714^GB215,101,5^FS" &
                            "^FO947,714^GB215,101,5^FS" &
                            "^FO317,812^GB215,101,5^FS" &
                            "^FO527,812^GB215,101,5^FS" &
                            "^FO737,812^GB215,101,5^FS" &
                            "^FO947,812^GB215,101,5^FS" &
                            "^FT54,201^A0N,42,43^FH\^CI28^FD1^FS^CI27" &
                            "^FT54,299^A0N,42,43^FH\^CI28^FD2^FS^CI27" &
                            "^FT54,394^A0N,42,43^FH\^CI28^FD3^FS^CI27" &
                            "^FT54,491^A0N,42,43^FH\^CI28^FD4^FS^CI27" &
                            "^FT54,587^A0N,42,43^FH\^CI28^FD5^FS^CI27" &
                            "^FT54,683^A0N,42,43^FH\^CI28^FD6^FS^CI27" &
                            "^FT54,782^A0N,42,43^FH\^CI28^FD7^FS^CI27" &
                            "^FT54,877^A0N,42,43^FH\^CI28^FD8^FS^CI27" &
                            "^FPH,1" &
                            "^FT145,202^A0N,36,35^FH\^CI28^FD" & SeqPart(0) & "^FS^CI27" &
                            "^FT145,290^A0N,33,33^FH\^CI28^FD" & SeqPart(1) & "^FS^CI27" &
                            "^FT145,388^A0N,33,33^FH\^CI28^FD" & SeqPart(2) & "^FS^CI27" &
                            "^FT145,487^A0N,33,33^FH\^CI28^FD" & SeqPart(3) & "^FS^CI27" &
                            "^FT145,582^A0N,33,33^FH\^CI28^FD" & SeqPart(4) & "^FS^CI27" &
                            "^FT145,681^A0N,33,33^FH\^CI28^FD" & SeqPart(5) & "^FS^CI27" &
                            "^FT145,776^A0N,33,33^FH\^CI28^FD" & SeqPart(6) & "^FS^CI27" &
                            "^FT145,872^A0N,33,33^FH\^CI28^FD" & SeqPart(7) & "^FS^CI27" &
                            "^FT346,199^A0N,33,20^FH\^CI28^FD" & SeqPartNoLH(0) & "^FS^CI27" &
                            "^FT346,290^A0N,33,20^FH\^CI28^FD" & SeqPartNoLH(1) & "^FS^CI27" &
                            "^FT346,388^A0N,33,20^FH\^CI28^FD" & SeqPartNoLH(2) & "^FS^CI27" &
                            "^FT346,487^A0N,33,20^FH\^CI28^FD" & SeqPartNoLH(3) & "^FS^CI27" &
                            "^FT346,582^A0N,33,20^FH\^CI28^FD" & SeqPartNoLH(4) & "^FS^CI27" &
                            "^FT346,681^A0N,33,20^FH\^CI28^FD" & SeqPartNoLH(5) & "^FS^CI27" &
                            "^FT346,776^A0N,33,20^FH\^CI28^FD" & SeqPartNoLH(6) & "^FS^CI27" &
                            "^FT346,872^A0N,33,20^FH\^CI28^FD" & SeqPartNoLH(7) & "^FS^CI27" &
                            "^FT562,199^A0N,33,25^FH\^CI28^FD" & SeqLotNoLH(0) & "^FS^CI27" &
                            "^FT562,290^A0N,33,25^FH\^CI28^FD" & SeqLotNoLH(1) & "^FS^CI27" &
                            "^FT562,388^A0N,33,25^FH\^CI28^FD" & SeqLotNoLH(2) & "^FS^CI27" &
                            "^FT562,487^A0N,33,25^FH\^CI28^FD" & SeqLotNoLH(3) & "^FS^CI27" &
                            "^FT562,582^A0N,33,25^FH\^CI28^FD" & SeqLotNoLH(4) & "^FS^CI27" &
                            "^FT562,681^A0N,33,25^FH\^CI28^FD" & SeqLotNoLH(5) & "^FS^CI27" &
                            "^FT562,776^A0N,33,25^FH\^CI28^FD" & SeqLotNoLH(6) & "^FS^CI27" &
                            "^FT562,872^A0N,33,25^FH\^CI28^FD" & SeqLotNoLH(7) & "^FS^CI27" &
                            "^FT761,199^A0N,33,20^FH\^CI28^FD" & SeqPartNoRH(0) & "^FS^CI27" &
                            "^FT761,290^A0N,33,20^FH\^CI28^FD" & SeqPartNoRH(1) & "^FS^CI27" &
                            "^FT761,388^A0N,33,20^FH\^CI28^FD" & SeqPartNoRH(2) & "^FS^CI27" &
                            "^FT761,487^A0N,33,20^FH\^CI28^FD" & SeqPartNoRH(3) & "^FS^CI27" &
                            "^FT761,582^A0N,33,20^FH\^CI28^FD" & SeqPartNoRH(4) & "^FS^CI27" &
                            "^FT761,681^A0N,33,20^FH\^CI28^FD" & SeqPartNoRH(5) & "^FS^CI27" &
                            "^FT761,776^A0N,33,20^FH\^CI28^FD" & SeqPartNoRH(6) & "^FS^CI27" &
                            "^FT761,872^A0N,33,20^FH\^CI28^FD" & SeqPartNoRH(7) & "^FS^CI27" &
                            "^FT979,199^A0N,33,25^FH\^CI28^FD" & SeqLotNoLH(0) & "^FS^CI27" &
                            "^FT979,290^A0N,33,25^FH\^CI28^FD" & SeqLotNoLH(1) & "^FS^CI27" &
                            "^FT979,388^A0N,33,25^FH\^CI28^FD" & SeqLotNoLH(2) & "^FS^CI27" &
                            "^FT979,487^A0N,33,25^FH\^CI28^FD" & SeqLotNoLH(3) & "^FS^CI27" &
                            "^FT979,582^A0N,33,25^FH\^CI28^FD" & SeqLotNoLH(4) & "^FS^CI27" &
                            "^FT979,681^A0N,33,25^FH\^CI28^FD" & SeqLotNoLH(5) & "^FS^CI27" &
                            "^FT979,776^A0N,33,25^FH\^CI28^FD" & SeqLotNoLH(6) & "^FS^CI27" &
                            "^FT979,872^A0N,33,25^FH\^CI28^FD" & SeqLotNoLH(7) & "^FS^CI27" &
                            "^PQ1,0,1,Y" &
                            "^XZ"

        SerialPrinter.Write(TmpBarcodeString)


    End Sub

    Private Sub InitGrid()

        ' FlexCell.Grid → DataGridView 변환
        With Grid1
            .Rows.Clear()
            .Columns.Clear()
            .ColumnCount = 8

            For i As Integer = 0 To 7
                .Columns(i).ReadOnly = True
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next

            .Columns(0).Width = 10
            .Columns(1).Width = 70
            .Columns(2).Width = 70
            .Columns(3).Width = 100
            .Columns(4).Width = 330
            .Columns(5).Width = 330
            .Columns(6).Width = 60

            ' 컬럼 헤더 설정 (FlexCell Cell(0,n) → HeaderText)
            .Columns(0).HeaderText = ""
            .Columns(1).HeaderText = "SEQ"
            .Columns(2).HeaderText = "INDEX"
            .Columns(3).HeaderText = "ALC CODE"
            .Columns(4).HeaderText = "LH BARCODE"
            .Columns(5).HeaderText = "RH BARCODE"
            .Columns(6).HeaderText = "DEC"
            .Columns(7).HeaderText = ""

            .Refresh()
        End With

    End Sub

    ' Grid1 셀 값 읽기 헬퍼 (범위 벗어나면 빈 문자열)
    Private Function GVal(r As Integer, c As Integer) As String
        If r >= 0 AndAlso r < Grid1.RowCount AndAlso c >= 0 AndAlso c < Grid1.ColumnCount Then
            Return CStr(If(Grid1.Rows(r).Cells(c).Value, ""))
        End If
        Return ""
    End Function

    ' Grid1 셀 값 쓰기 헬퍼 (범위 체크 포함)
    Private Sub SVal(r As Integer, c As Integer, v As String)
        If r >= 0 AndAlso r < Grid1.RowCount AndAlso c >= 0 AndAlso c < Grid1.ColumnCount Then
            Grid1.Rows(r).Cells(c).Value = v
        End If
    End Sub

    Private Function ConvertSTr(ByVal str As String) As String
        Dim tmp As String = ""
        'Try
        tmp = Trim(str)
        'Catch ex As Exception
        'End Try
        Return tmp
    End Function

    Private Sub LoadData()

        Dim i As Integer
        ConnectionOpenMdb()

        Dim Rs As New ADODB.Recordset
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic

        Rs.Open("SELECT * FROM Table_EndSeq WHERE JobDate = '" & Format(Now, "yyyy-MM-dd") & "' ORDER BY LEN(Seq),Seq", MdbConnect)

        ReDim nowSeq(Rs.RecordCount)
        ReDim nowALc1(Rs.RecordCount)
        ReDim nowALc2(Rs.RecordCount)
        ReDim nowALc3(Rs.RecordCount)
        ReDim nowALc4(Rs.RecordCount)
        ReDim nowALc5(Rs.RecordCount)
        ReDim nowALc6(Rs.RecordCount)
        ReDim nowALc7(Rs.RecordCount)
        ReDim nowALc8(Rs.RecordCount)
        ReDim nowALcDec1(Rs.RecordCount)
        ReDim nowALcDec2(Rs.RecordCount)
        ReDim nowALcDec3(Rs.RecordCount)
        ReDim nowALcDec4(Rs.RecordCount)
        ReDim nowALcDec5(Rs.RecordCount)
        ReDim nowALcDec6(Rs.RecordCount)
        ReDim nowALcDec7(Rs.RecordCount)
        ReDim nowALcDec8(Rs.RecordCount)

        If Rs.RecordCount = 1 Then

                i = 0
                nowSeq(0) = Rs.Fields("Seq").Value
                nowALc1(0) = Rs.Fields("Alc1").Value
                nowALc2(0) = Rs.Fields("Alc2").Value
                nowALc3(0) = Rs.Fields("Alc3").Value
                nowALc4(0) = Rs.Fields("Alc4").Value
                nowALc5(0) = Rs.Fields("Alc5").Value
                nowALc6(0) = Rs.Fields("Alc6").Value
                nowALc7(0) = Rs.Fields("Alc7").Value
                nowALc8(0) = Rs.Fields("Alc8").Value
                Try
                    nowALcDec1(i) = Rs.Fields("Alc1OK").Value
                Catch ex As Exception
                    nowALcDec1(i) = ""
                End Try
                Try
                    nowALcDec2(i) = Rs.Fields("Alc2OK").Value
                Catch ex As Exception
                    nowALcDec2(i) = ""
                End Try
                Try
                    nowALcDec3(i) = Rs.Fields("Alc3OK").Value
                Catch ex As Exception
                    nowALcDec3(i) = ""
                End Try
                Try
                    nowALcDec4(i) = Rs.Fields("Alc4OK").Value
                Catch ex As Exception
                    nowALcDec4(i) = ""
                End Try
                Try
                    nowALcDec5(i) = Rs.Fields("Alc5OK").Value
                Catch ex As Exception
                    nowALcDec5(i) = ""
                End Try
                Try
                    nowALcDec6(i) = Rs.Fields("Alc6OK").Value
                Catch ex As Exception
                    nowALcDec6(i) = ""
                End Try
                Try
                    nowALcDec7(i) = Rs.Fields("Alc7OK").Value
                Catch ex As Exception
                    nowALcDec7(i) = ""
                End Try
                Try
                    nowALcDec8(i) = Rs.Fields("Alc8OK").Value
                Catch ex As Exception
                    nowALcDec8(i) = ""
                End Try

            ElseIf Rs.RecordCount > 1 Then

                Rs.MoveFirst()
                i = 0
                Do Until Rs.EOF
                    nowSeq(i) = Rs.Fields("Seq").Value
                    nowALc1(i) = Rs.Fields("Alc1").Value
                    nowALc2(i) = Rs.Fields("Alc2").Value
                    nowALc3(i) = Rs.Fields("Alc3").Value
                    nowALc4(i) = Rs.Fields("Alc4").Value
                    nowALc5(i) = Rs.Fields("Alc5").Value
                    nowALc6(i) = Rs.Fields("Alc6").Value
                    nowALc7(i) = Rs.Fields("Alc7").Value
                    nowALc8(i) = Rs.Fields("Alc8").Value
                    Try

                        If nowALc1(i) = "PASS" Then
                            nowALcDec1(i) = "OK"
                        Else
                            nowALcDec1(i) = Rs.Fields("Alc1OK").Value
                        End If
                    Catch ex As Exception
                        nowALcDec1(i) = ""
                    End Try
                    Try

                        If nowALc2(i) = "PASS" Then
                            nowALcDec2(i) = "OK"
                        Else
                            nowALcDec2(i) = Rs.Fields("Alc2OK").Value
                        End If
                    Catch ex As Exception
                        nowALcDec2(i) = ""
                    End Try
                    Try
                        If nowALc3(i) = "PASS" Then
                            nowALcDec3(i) = "OK"
                        Else
                            nowALcDec3(i) = Rs.Fields("Alc3OK").Value
                        End If

                    Catch ex As Exception
                        nowALcDec3(i) = ""
                    End Try
                    Try
                        If nowALc4(i) = "PASS" Then
                            nowALcDec4(i) = "OK"
                        Else
                            nowALcDec4(i) = Rs.Fields("Alc4OK").Value
                        End If
                    Catch ex As Exception
                        nowALcDec4(i) = ""
                    End Try
                    Try
                        If nowALc5(i) = "PASS" Then
                            nowALcDec5(i) = "OK"
                        Else
                            nowALcDec5(i) = Rs.Fields("Alc5OK").Value
                        End If
                    Catch ex As Exception
                        nowALcDec5(i) = ""
                    End Try
                    Try
                        If nowALc6(i) = "PASS" Then
                            nowALcDec6(i) = "OK"
                        Else
                            nowALcDec6(i) = Rs.Fields("Alc6OK").Value
                        End If
                    Catch ex As Exception
                        nowALcDec6(i) = ""
                    End Try
                    Try
                        If nowALc7(i) = "PASS" Then
                            nowALcDec7(i) = "OK"
                        Else
                            nowALcDec7(i) = Rs.Fields("Alc7OK").Value
                        End If
                    Catch ex As Exception
                        nowALcDec7(i) = ""
                    End Try
                    Try
                        If nowALc8(i) = "PASS" Then
                            nowALcDec8(i) = "OK"
                        Else
                            nowALcDec8(i) = Rs.Fields("Alc8OK").Value
                        End If
                    Catch ex As Exception
                        nowALcDec8(i) = ""
                    End Try

                    i = i + 1
                    Rs.MoveNext()
                Loop
            End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionCloseMdb()

    End Sub

    Private Sub GetAlcTarget(ByVal str As String)

        Dim Rs As New ADODB.Recordset
        ConnectionOpenMdb()
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        Rs.Open("SELECT * FROM Table_ALCCODE WHERE ALCCODE = '" & str & "'", MdbConnect)
        If Rs.RecordCount = 1 Then
            NowLhTarget = Replace(Rs.Fields("PartNoLH").Value, "-", "")
            NowRhTarget = Replace(Rs.Fields("PartNoRH").Value, "-", "")
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionCloseMdb()

    End Sub

    Private Sub ShowGrid()

        ' FlexCell.AddItem(탭구분) → DataGridView.Rows.Add 변환
        ' 컬럼 순서: [0]spacer [1]SEQ [2]INDEX [3]ALC CODE [4]LH BARCODE [5]RH BARCODE [6]DEC [7]empty
        For i = 0 To UBound(nowSeq) - 1
            Grid1.Rows.Add(nowSeq(i), nowSeq(i), "1", nowALc1(i), "", "", nowALcDec1(i))
            Grid1.Rows.Add(nowSeq(i), nowSeq(i), "2", nowALc2(i), "", "", nowALcDec2(i))
            Grid1.Rows.Add(nowSeq(i), nowSeq(i), "3", nowALc3(i), "", "", nowALcDec3(i))
            Grid1.Rows.Add(nowSeq(i), nowSeq(i), "4", nowALc4(i), "", "", nowALcDec4(i))
            Grid1.Rows.Add(nowSeq(i), nowSeq(i), "5", nowALc5(i), "", "", nowALcDec5(i))
            Grid1.Rows.Add(nowSeq(i), nowSeq(i), "6", nowALc6(i), "", "", nowALcDec6(i))
            Grid1.Rows.Add(nowSeq(i), nowSeq(i), "7", nowALc7(i), "", "", nowALcDec7(i))
            Grid1.Rows.Add(nowSeq(i), nowSeq(i), "8", nowALc8(i), "", "", nowALcDec8(i))
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        FrmRegisterSeq.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        FrmPort.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FrmManualBarcode.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        InitGrid()
        LoadData()
        ShowGrid()
    End Sub

    Private Sub SerialOpen()

        Try
            If SerialPrinter.IsOpen() = True Then
                SerialPrinter.Close()
            End If
            SerialPrinter.PortName = PortNumberPrinter
            SerialPrinter.BaudRate = 9600
            SerialPrinter.DataBits = 8
            SerialPrinter.Open()
            'MsgBox("Serial Printer Open Success" & PortNumberPrinter)
        Catch ex As Exception
            MsgBox("Serial Printer Open Fail")
        End Try

        Try
            If SerialSCanner.IsOpen() = True Then
                SerialSCanner.Close()
            End If
            SerialSCanner.PortName = PortNumberScanner
            SerialSCanner.BaudRate = 9600
            SerialSCanner.DataBits = 8
            SerialSCanner.Parity = IO.Ports.Parity.None
            SerialSCanner.Handshake = Ports.Handshake.RequestToSendXOnXOff
            SerialSCanner.Open()
            'WriteTxtMessage("Serial Scanner Open Success " & PortNumberScanner)
        Catch ex As Exception
            MsgBox("Serial Scanner Open Fail")
        End Try

    End Sub

    Private Sub SerialSCanner_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialSCanner.DataReceived
        Dim Incoming As String = SerialSCanner.ReadLine()
        Dim ScanData As String = Mid$(Incoming, 1, Len(Incoming) - 1)
        SerialSCanner.DiscardInBuffer()
        Me.Invoke(Sub() ProcessScanData(ScanData))
    End Sub

    Private Sub ProcessScanData(ScanData As String)
        Dim i As Integer
        Dim NowSeq As Integer
        Dim SplitTMp() As String
        Dim StartSeq As Integer

        Try
            ' FlexCell: Grid1.Rows-1 (1-기반) → DGV: Grid1.Rows.Count (0-기반)
            NowSeq = 0
            For i = 0 To Grid1.Rows.Count - 1
                If GVal(i, 6) = "" Then
                    NowSeq = i
                    Exit For
                End If
            Next
            GetAlcTarget(GVal(NowSeq, 3))
            If CheckDuplicate(ScanData) = False Then
                FLagALarm = False
                If ScanData.Contains(NowLhTarget) = True And GVal(NowSeq, 4) = "" And GVal(NowSeq, 5) <> "" Then
                    SplitTMp = Split(ScanData, Chr(29))
                    Grid1.Rows(NowSeq).Cells(4).Value = SplitTMp(2) & SplitTMp(5)
                    TMpScandataLH = ScanData
                    TmpPCodeLH = SplitTMp(2)
                    TmpTcodeLH = SplitTMp(5)
                    DingDOng()
                ElseIf ScanData.Contains(NowRhTarget) = True And GVal(NowSeq, 4) = "" And GVal(NowSeq, 5) = "" Then
                    SplitTMp = Split(ScanData, Chr(29))
                    Grid1.Rows(NowSeq).Cells(5).Value = SplitTMp(2) & SplitTMp(5)
                    TMpScandataRH = ScanData
                    TmpPCodeRH = SplitTMp(2)
                    TmpTcodeRH = SplitTMp(5)
                    DingDOng()
                Else
                    NG()
                End If
            Else
                FLagALarm = True
                NG()
            End If

            If GVal(NowSeq, 4) <> "" And GVal(NowSeq, 5) <> "" Then
                Grid1.Rows(NowSeq).Cells(6).Value = "OK"
                SaveDb(GVal(NowSeq, 1), GVal(NowSeq, 2), TmpPCodeLH, TmpTcodeLH, TMpScandataLH, TmpPCodeRH, TmpTcodeRH, TMpScandataRH)
                UpdateDb(Format(Now, "yyyy-MM-dd"), GVal(NowSeq, 1), GVal(NowSeq, 2))
                Dim tmp As Integer = CInt(GVal(NowSeq, 1)) - NowSeq
                For i = NowSeq + 1 To (NowSeq + 8 - CInt(GVal(NowSeq, 2)))
                    If GVal(i, 3) = "PASS" Then
                        Grid1.Rows(i).Cells(6).Value = "OK"
                        UpdateDb(Format(Now, "yyyy-MM-dd"), GVal(i, 1), GVal(i, 2))
                    End If
                Next
                StartSeq = NowSeq - CInt(GVal(NowSeq, 2)) + 1
                If GVal(StartSeq, 6) = "OK" And GVal(StartSeq + 1, 6) = "OK" And GVal(StartSeq + 2, 6) = "OK" And
                    GVal(StartSeq + 3, 6) = "OK" And GVal(StartSeq + 4, 6) = "OK" And GVal(StartSeq + 5, 6) = "OK" And
                    GVal(StartSeq + 6, 6) = "OK" And GVal(StartSeq + 7, 6) = "OK" Then
                    CarType = "RS4"
                    LotNo = Format(Now, "yyyy-MM-dd")
                    DeliveryDate = Format(Now, "yyyy-MM-dd")
                    OkNumber = GVal(NowSeq, 1)
                    SeqPart(0) = Cnvt(GVal(StartSeq, 3))
                    SeqPart(1) = Cnvt(GVal(StartSeq + 1, 3))
                    SeqPart(2) = Cnvt(GVal(StartSeq + 2, 3))
                    SeqPart(3) = Cnvt(GVal(StartSeq + 3, 3))
                    SeqPart(4) = Cnvt(GVal(StartSeq + 4, 3))
                    SeqPart(5) = Cnvt(GVal(StartSeq + 5, 3))
                    SeqPart(6) = Cnvt(GVal(StartSeq + 6, 3))
                    SeqPart(7) = Cnvt(GVal(StartSeq + 7, 3))

                    '[)>06V2812P88310T4020NNBSEXXXXXXXXXT220121S1B2A0000024MYC#[)>06VG2M5P80650T4000SXXXXT211023INRA@RS4CLA0078CRS4CLA2110230078#[)>06VG2M5P80610T4000SXXXXT211023INRA@RS4SLA0256CRS4SLA2110230256#[)>06VSJNTP88340T4200SET220112K001ARS4 12C LH 
                    '[)>06V2812P88410T4040NNBSEXXXXXXXXXT220204S1B2A0000005MYC#[)>06VG2M5P80620T4000SXXXXT211025INRA@RS4SRA0871CRS4SRA2110250871#[)>06VSJNTP88440T4600SET220126K001ARS4 11C RHSR0009MNCHW100SW101

                    'Grid1.Rows(NowSeq).Cells(4).Value = SplitTMp(2) & SplitTMp(5) 'LH
                    'P88410T4040NNB 'T220204S1B2A0000005

                    'Grid1.Rows(NowSeq).Cells(5).Value = SplitTMp(2) & SplitTMp(5) 'RH
                    'P88410T4040NNB 'T220204S1B2A0000005

                    SeqPartNoLH(0) = ReturnChkPartNo(GVal(StartSeq, 4))
                    SeqLotNoLH(0) = ReturnChkLotNo(GVal(StartSeq, 4))

                    SeqPartNoLH(1) = ReturnChkPartNo(GVal(StartSeq + 1, 4))
                    SeqLotNoLH(1) = ReturnChkLotNo(GVal(StartSeq + 1, 4))

                    SeqPartNoLH(2) = ReturnChkPartNo(GVal(StartSeq + 2, 4))
                    SeqLotNoLH(2) = ReturnChkLotNo(GVal(StartSeq + 2, 4))

                    SeqPartNoLH(3) = ReturnChkPartNo(GVal(StartSeq + 3, 4))
                    SeqLotNoLH(3) = ReturnChkLotNo(GVal(StartSeq + 3, 4))

                    SeqPartNoLH(4) = ReturnChkPartNo(GVal(StartSeq + 4, 4))
                    SeqLotNoLH(4) = ReturnChkLotNo(GVal(StartSeq + 4, 4))

                    SeqPartNoLH(5) = ReturnChkPartNo(GVal(StartSeq + 5, 4))
                    SeqLotNoLH(5) = ReturnChkLotNo(GVal(StartSeq + 5, 4))

                    SeqPartNoLH(6) = ReturnChkPartNo(GVal(StartSeq + 6, 4))
                    SeqLotNoLH(6) = ReturnChkLotNo(GVal(StartSeq + 6, 4))

                    SeqPartNoLH(7) = ReturnChkPartNo(GVal(StartSeq + 7, 4))
                    SeqLotNoLH(7) = ReturnChkLotNo(GVal(StartSeq + 7, 4))

                    SeqPartNoRH(0) = ReturnChkPartNo(GVal(StartSeq, 5))
                    SeqLotNoRH(0) = ReturnChkLotNo(GVal(StartSeq, 5))

                    SeqPartNoRH(1) = ReturnChkPartNo(GVal(StartSeq + 1, 5))
                    SeqLotNoRH(1) = ReturnChkLotNo(GVal(StartSeq + 1, 5))

                    SeqPartNoRH(2) = ReturnChkPartNo(GVal(StartSeq + 2, 5))
                    SeqLotNoRH(2) = ReturnChkLotNo(GVal(StartSeq + 2, 5))

                    SeqPartNoRH(3) = ReturnChkPartNo(GVal(StartSeq + 3, 5))
                    SeqLotNoRH(3) = ReturnChkLotNo(GVal(StartSeq + 3, 5))

                    SeqPartNoRH(4) = ReturnChkPartNo(GVal(StartSeq + 4, 5))
                    SeqLotNoRH(4) = ReturnChkLotNo(GVal(StartSeq + 4, 5))

                    SeqPartNoRH(5) = ReturnChkPartNo(GVal(StartSeq + 5, 5))
                    SeqLotNoRH(5) = ReturnChkLotNo(GVal(StartSeq + 5, 5))

                    SeqPartNoRH(6) = ReturnChkPartNo(GVal(StartSeq + 6, 5))
                    SeqLotNoRH(6) = ReturnChkLotNo(GVal(StartSeq + 6, 5))

                    SeqPartNoRH(7) = ReturnChkPartNo(GVal(StartSeq + 7, 5))
                    SeqLotNoRH(7) = ReturnChkLotNo(GVal(StartSeq + 7, 5))

                    BarcodePrint()

                End If
            End If
            ' SetFocus → DGV CurrentCell
            If Grid1.Rows.Count > NowSeq Then Grid1.CurrentCell = Grid1.Rows(NowSeq).Cells(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Function ReturnChkPartNo(ByVal str As String)

        Dim tmp As String = ""
        Try
            tmp = Mid(str, 2, 13)
        Catch ex As Exception
        End Try
        Return tmp

    End Function

    Private Function ReturnChkLotNo(ByVal str As String)

        Dim tmp As String = ""
        Try
            tmp = "20" & Mid(str, 16, 6)
        Catch ex As Exception
        End Try
        Return tmp

    End Function

    Private Function Cnvt(ByVal str As String) As String
        Dim tmp = ""
        If str.Length = 6 Then
            tmp = str
        End If
        Return tmp
    End Function

    ' (중복된 GVal 정의 제거 — 라인 336의 GVal 사용)

    Private Sub SaveDb(ByVal strSeq As String, ByVal strIndex As String, ByVal PcodeLH As String, ByVal TCodeLH As String, ByVal ScanDataLH As String, ByVal PcodeRH As String, ByVal TCodeRH As String, ByVal ScanDataRH As String)

        Dim strSQL As String = ""
        ConnectionOpenMdb()

        strSQL = "INSERT INTO TABLE_MAIN (JobDate,JobTime,jobSeq,jobIndex,PcodeLH,TCodeLH,ScanDataLH,PcodeRH,TCodeRH,ScanDataRH) VALUES (" &
                       "'" & Format(Now, "yyyy-MM-dd") & "','" &
                               Format(Now, "HH:mm:ss") & "','" &
                               strSeq & "','" &
                               strIndex & "','" &
                               PcodeLH & "','" &
                               TCodeLH & "','" &
                               ScanDataLH & "','" &
                               PcodeRH & "','" &
                               TCodeRH & "','" &
                               ScanDataRH & "')"

        MdbConnect.Execute(strSQL)
        ConnectionCloseMdb()

    End Sub

    Private Sub UpdateDb(ByVal strDate As String, ByVal strSeq As String, ByVal strIndex As String)

        Dim tmp As Boolean = False
        Dim Rs As New ADODB.Recordset
        ConnectionOpenMdb()
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        Rs.Open("SELECT * FROM Table_EndSeq WHERE JobDate = '" & strDate & "' AND Seq = '" & strSeq & "'", MdbConnect)
        If Rs.RecordCount = 1 Then
            Rs.Fields("ALC" & strIndex & "OK").Value = "OK"
            Rs.Update()
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionCloseMdb()

    End Sub

    Private Function CheckDuplicate(ByVal strdata As String) As Boolean

        Dim tmp As Boolean = False
        Dim Rs As New ADODB.Recordset
        ConnectionOpenMdb()
        Rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        Rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        Rs.LockType = ADODB.LockTypeEnum.adLockOptimistic
        Rs.Open("SELECT * FROM Table_MAIN WHERE ScanDataLH = '" & strdata & "' OR ScanDataRH = '" & strdata & "'", MdbConnect)
        If Rs.RecordCount >= 1 Then
            tmp = True
        End If
        Rs.ActiveConnection = Nothing
        Rs.Close()
        ConnectionCloseMdb()

        Return tmp

    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If FLagALarm = True And LbAlarm.Visible = False Then
            LbAlarm.Visible = True
        ElseIf FLagALarm = False And LbAlarm.Visible = True Then
            LbAlarm.Visible = False
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        FrmSearch.show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim ScanData As String =
         "[)><rs>06<gs>V2812<gs>P88310T4230DUE<gs>S<gs>EXXXXXXXXX<gs>T250514S1B2A0000029<gs>MY<gs>C<gs><rs><eot>#[)><rs>06<gs>VG2M5<gs>P80650T4000<gs>SXXXX<gs>T250120INRA@RS4CLA0075<gs>CRS4CLA2501200075<gs><rs><eot>#[)><rs>06<gs>VG2M5<gs>P80610T4000<gs>SXXXX<gs>T250123INRA@RS4SLA0748<gs>CRS4SLA2501230748<gs><rs><eot>#[)><rs>06<gs>VSJNT<gs>P88340T4200<gs>S<gs>E<gs>T250502K001ARS4 12C LH SL0032<gs>MN<gs>CHW100SW103<gs><rs><eot>"
        ProcessScanData(ScanData)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim ScanData As String =
         "[)><rs>06<gs>V2812<gs>P88410T4480DUE<gs>S<gs>EXXXXXXXXX<gs>T250514S1B2A0000030<gs>MY<gs>C<gs><rs><eot>#[)><rs>06<gs>VG2M5<gs>P80620T4000<gs>SXXXX<gs>T250122INRA@RS4SRA0124<gs>CRS4SRA2501220124<gs><rs><eot>#[)><rs>06<gs>VSJNT<gs>P88440T4600<gs>S<gs>E<gs>T250428K001ARS4 11C RHSR0035<gs>MN<gs>CHW100SW103<gs><rs><eot>"
        ProcessScanData(ScanData)
    End Sub
End Class
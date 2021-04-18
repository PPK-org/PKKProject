using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogText : MonoBehaviour
{
    public static string[] sentences;
    public static string namadialog;
    public static int index;
    //sentences[] = "";
    public static void EventText()
    {
        if(DataPlayer.eventCount == 0)
        {
            namadialog = "System";
            sentences = new string[5];
            index = 0;
            sentences[0] = "Tutorial";
            sentences[1] = "Untuk bergerak player dapat menekan tombol kiri atau kanan sesuai arah yang diinginkan";
            sentences[2] = "Untuk melompat player dapat menekan tombol lompat";
            sentences[3] = "Untuk menyerang player dapat menekan tombol Atk";
            sentences[4] = "Ikuti tanda yang telah disediakan untuk tetap berada pada jalur yang tepat";
        }
        else if(DataPlayer.eventCount == 2)
        {
            namadialog = "Kocheng";
            sentences = new string[8];
            index = 0;
            sentences[0] = "Hei";
            sentences[1] = "Apa kau ingin pergi sekarang?";
            sentences[2] = "Menyerahlah";
            sentences[3] = "Manusia itu hanya mitos, mereka tidak pernah ada di dunia ini";
            sentences[4] = "Sejauh apapun kau mencari mereka, kau tidak akan menemukannya";
            sentences[5] = "...";
            sentences[6] = "Apa kau mendengarku?";
            sentences[7] = "Terserah lah, aku hanya tidak mau kau menyia-nyiakan hidupmu hanya untuk sesuatu yang tidak ada";
        }else if(DataPlayer.eventCount == 4)
        {
            namadialog = "System";
            sentences = new string[7];
            index = 0;
            sentences[0] = "Toturial";
            sentences[1] = "Ketika muncul tanda seru di atas kepala player";
            sentences[2] = "Maka akan muncul tombol interaksi dan menggantikan tombol Atk";
            sentences[3] = "Player dapat menekan tombol interaksi untuk berinteraksi";
            sentences[4] = "Player dapat save data permainan pada checkpoint yang telah disediakan";
            sentences[5] = "Darah player akan seketika penuh ketika berinteraksi dengan checkpoint";
            sentences[6] = "Ketika player telah berinteraksi dengan checkpoint maka ketika player mati akan dihidupkan di tempat terakhir player berinteraksi dengan checkpoint";
            
        }
    }
}

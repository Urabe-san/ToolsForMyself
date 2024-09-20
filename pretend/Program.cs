using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pretend
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProcessStartInfoオブジェクトを作成する
            System.Diagnostics.ProcessStartInfo psi =
                new System.Diagnostics.ProcessStartInfo();
            //起動するアプリケーションの実行ファイルのパスを設定する
            psi.FileName = "notepad.exe";
            //ユーザー名を設定する
            psi.UserName = "u330908";
            //パスワードを設定する
            string pwd = "myPassword";
            //文字列をSecureStringに変換する
            System.Security.SecureString ssPwd = new System.Security.SecureString();
            foreach (char c in pwd)
            {
                ssPwd.AppendChar(c);
            }
            psi.Password = ssPwd;
            //ドメインを設定する。ローカルアカウントの場合はnullでよい。
            psi.Domain = "MHI";
            //アクセスが許可されている作業ディレクトリを設定する
            psi.WorkingDirectory = @"C:\temp";
            //UseShellExecuteはFalseにする
            psi.UseShellExecute = false;

            //アプリケーションを起動する
            System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);
        }
    }
}

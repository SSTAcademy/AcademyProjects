using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyConsole
{
    public class SqlDbConnection:IDisposable//using için gerekli olan interface'ten miras al

    {
        public bool IsDisposed { get; private set; } = false;
        public SqlConnection Connection { get; set; } //özel bir instance
        public string TableName { get; set; }
        public SqlDbConnection(string tableName)//constructor
        {
            TableName = tableName;
            Connection = new SqlConnection("");//içine boş bir string koyduk
            Console.WriteLine("tablo adi" + tableName);
        }

        public void Show()
        {
            Console.WriteLine(IsDisposed);//sadece parametreyi yazdırdık.Başka işlemi yok.
        }
        
        public void Dispose()//override metot
        {
            IsDisposed = true;
            if (Connection != null)//bağlantı var mı yok mu?
            {
                if (Connection.State is not ConnectionState.Closed)//bağlantı durumu kapalı değilse kapat
                {
                    Connection.Close();
                }
                Connection.Dispose();//connection için özel dispose metotunu çağır
                Connection = null;//constructor içinde verdiğimiz stringi null yap
                Console.WriteLine("Disposing..");

            }

        }
    }
}

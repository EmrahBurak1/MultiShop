using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {
        public string _host { get; set; }
        public int _port { get; set; }

        private ConnectionMultiplexer _connectionMultiplexer;
        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}"); //Connect methodu çağırıldığında host ve port numarasına erişim sğalayabileceğiz.

        public IDatabase GetDb(int db = 1)=>_connectionMultiplexer.GetDatabase(0); //Getdb bize veritabanını getirir. db=1 dememimiz sebebi redise db ye baktığımız zaman karşımıza 16 tane db örneği çıkıyor bu dblerden her birini domain için kullanabiliyoruz örneğin development için product için test için farklı dbleri kullanabiliyoruz. 0.sırada olan database'i getir diyoruz.

    }
}

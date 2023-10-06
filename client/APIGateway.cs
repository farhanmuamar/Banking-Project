using System.Net;
using System.Text;
using client.Models;
using Newtonsoft.Json;

namespace client
{
    public class APIGateway
    {
        private string url = "http://localhost:5063/api";
        private HttpClient client = new HttpClient();

        #region Nasabah
        public List<NasabahModel> ListNasabah()
        {
            url = url + "/nasabah";
            List<NasabahModel> nasabah = new List<NasabahModel>();

            if (url.Trim().Substring(0, 5).ToLower() == "https") {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }

            try 
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var datacol = JsonConvert.DeserializeObject<List<NasabahModel>>(result);

                    if (datacol != null) 
                    {
                        nasabah = datacol;
                    }
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error occured at the API Endpoint, Error info, " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured at the API Endpoint, Error info, " + ex.Message);
            }

            finally {}

            return nasabah;
        }

        public NasabahModel CreateNasabah(NasabahModel nasabah)
        {
            url = url + "/nasabah";

            if (url.Trim().Substring(0, 5).ToLower() == "https") {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }

            string json = JsonConvert.SerializeObject(nasabah);

            try 
            {
                HttpResponseMessage response = client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<NasabahModel>(result);

                    if (data != null) 
                    {
                        nasabah = data;
                    }
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error occured at the API Endpoint, Error info, " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured at the API Endpoint, Error info, " + ex.Message);
            }

            finally {}

            return nasabah;
        }
    
        public NasabahModel GetNasabah(int id)
        {
            NasabahModel nasabah = new NasabahModel();

            url = url + "/nasabah/" +id;

            if (url.Trim().Substring(0, 5).ToLower() == "https") {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }

            try 
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<NasabahModel>(result);

                    if (data != null) 
                    {
                        nasabah = data;
                    }
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error occured at the API Endpoint, Error info, " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured at the API Endpoint, Error info, " + ex.Message);
            }

            finally {}

            return nasabah;
        }
    
        public void UpdateNasabah(NasabahModel nasabah)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https") {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }

            int id = nasabah.AccountId;
            url = url + "/nasabah/" + id;

            string json = JsonConvert.SerializeObject(nasabah);

            try 
            {
                HttpResponseMessage response = client.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error occured at the API Endpoint, Error info, " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured at the API Endpoint, Error info, " + ex.Message);
            }

            finally {}

            return;
        }

        public void DeleteNasabah(int id)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https") {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            
            url = url + "/nasabah/" + id;
            
            try 
            {
                HttpResponseMessage response = client.DeleteAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error occured at the API Endpoint, Error info, " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured at the API Endpoint, Error info, " + ex.Message);
            }

            finally {}

            return;
        }
        
        #endregion

        #region Transaksi
        public List<TransaksiModel> ListTransaksi()
        {
            url = url + "/transaksi";
            List<TransaksiModel> transaksi = new List<TransaksiModel>();

            if (url.Trim().Substring(0, 5).ToLower() == "https") {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }

            try 
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<List<TransaksiModel>>(result);

                    if (data != null) 
                    {
                        transaksi = data;
                    }
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error occured at the API Endpoint, Error info, " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured at the API Endpoint, Error info, " + ex.Message);
            }

            finally {}

            return transaksi;
        }

        public TransaksiModel CreateTransaksi(TransaksiModel transaksi)
        {
            url = url + "/transaksi";

            if (url.Trim().Substring(0, 5).ToLower() == "https") {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }

            string json = JsonConvert.SerializeObject(transaksi);

            try 
            {
                HttpResponseMessage response = client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<TransaksiModel>(result);

                    if (data != null) 
                    {
                        transaksi = data;
                    }
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error occured at the API Endpoint, Error info, " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured at the API Endpoint, Error info, " + ex.Message);
            }

            finally {}

            return transaksi;
        }
    
        public TransaksiModel GetTransaksi(int id)
        {
            TransaksiModel transaksi = new TransaksiModel();

            url = url + "/transaksi/" + id;

            if (url.Trim().Substring(0, 5).ToLower() == "https") {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }

            try 
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<TransaksiModel>(result);

                    if (data != null) 
                    {
                        transaksi = data;
                    }
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error occured at the API Endpoint, Error info, " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured at the API Endpoint, Error info, " + ex.Message);
            }

            finally {}

            return transaksi;
        }

        public void UpdateTransaksi(TransaksiModel transaksi)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https") {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }

            int id = transaksi.Id;
            url = url + "/nasabah/" + id;

            string json = JsonConvert.SerializeObject(transaksi);

            try 
            {
                HttpResponseMessage response = client.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;

                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error occured at the API Endpoint, Error info, " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured at the API Endpoint, Error info, " + ex.Message);
            }

            finally {}

            return;
        }
   
        public void DeleteTransaksi(int id)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https") {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            
            url = url + "/transaksi/" + id;
            
            try 
            {
                HttpResponseMessage response = client.DeleteAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error occured at the API Endpoint, Error info, " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured at the API Endpoint, Error info, " + ex.Message);
            }

            finally {}

            return;
        }
        

        #endregion
    }
}
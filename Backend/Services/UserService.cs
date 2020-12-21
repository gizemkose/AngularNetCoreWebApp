using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.DTO;
using WebApi.Entities;
using WebApi.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace WebApi.Services
{
  public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<List<SaleListDTO>> GetSales(GetSalesDTO getSalesRequest, string apiCode);
    }   
    public class UserService : IUserService
    {     

        public async Task<User> Authenticate(string username, string password)
        {
            ResponseEntity<LoginResponseDTO> response = await LoginRequest(username, password);
            if (response.Result == "false")
            {
                return null;
            }
            User user = new User
            {
                UserName = response.Response.Username,
                Id = response.Response.UserId,
                ApiCode = response.Response.ApiCode

            };         
            return user;
        }

        [HttpPost]
        public async Task<ResponseEntity<LoginResponseDTO>> LoginRequest(string username, string password)
        {  
            LoginRequestDTO request = new LoginRequestDTO
            {
                UserName = username,
                Password = password
            };

            using (var httpClient = new System.Net.Http.HttpClient())
            {                
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
               
                ResponseEntity<LoginResponseDTO> responseDto;

                using (var response = await httpClient.PostAsync("https://e-out-test.stockmount.com/api/user/dologin", content))
                {
                    response.EnsureSuccessStatusCode();
                    string responseStr = await response.Content.ReadAsStringAsync();
                    try
                    {
                        responseDto = JsonConvert.DeserializeObject<ResponseEntity<LoginResponseDTO>>(responseStr);
                        return responseDto;
                    }
                    catch (Exception ex)
                    {                     
                        throw ex;
                    }       
                }
            }
        }
        [HttpPost]
        public async Task<List<SaleListDTO>> GetSales(GetSalesDTO getSales,string apiCode)
        {
            GetSalesRequestDTO getSalesRequest = new GetSalesRequestDTO
            {
                ApiCode = apiCode,
                StoreId = getSales.StoreId,
                OrderStatus=getSales.OrderStatus,
                InvoiceStatus=getSales.InvoiceStatus
            };
            using (var httpClient = new System.Net.Http.HttpClient())
            {                
                StringContent content = new StringContent(JsonConvert.SerializeObject(getSalesRequest), Encoding.UTF8, "application/json");

                ResponseEntity<GetSalesResponseDTO> responseObject;

                using (var response = await httpClient.PostAsync("https://e-out-test.stockmount.com/api/Integration/GetSales", content))
                {
                    response.EnsureSuccessStatusCode();
                    string responseStr = await response.Content.ReadAsStringAsync();
                    try
                    {
                        responseObject = JsonConvert.DeserializeObject<ResponseEntity<GetSalesResponseDTO>>(responseStr);
                        return convertToSaleListDTO(responseObject);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        private List<SaleListDTO> convertToSaleListDTO(ResponseEntity<GetSalesResponseDTO> responseObject)
        {
            GetSalesResponseDTO getSalesResponseDTO = responseObject.Response;
            List<SaleListDTO> saleList = new List<SaleListDTO>();
            foreach (Orders order in getSalesResponseDTO.Orders)
            {
                foreach (OrderDetails orderDetail in order.OrderDetails)
                {
                    SaleListDTO sale = new SaleListDTO();
                    sale.Address = order.Address;
                    sale.CargoCompany = orderDetail.CargoCompany;
                    sale.CargoDate = orderDetail.CargoDate;
                    sale.CargoPayment = orderDetail.CargoPayment;
                    sale.City = order.City;
                    sale.CompanyTitle = order.CompanyTitle;
                    sale.Name = order.Name;
                    sale.OrderDate = order.OrderDate;
                    sale.OrderId = order.OrderId;
                    sale.Price = orderDetail.Price;
                    sale.ProductName = orderDetail.ProductName;
                    sale.Surname = order.Surname;
                    sale.TaxNumber = order.TaxNumber;
                    sale.Telephone = order.Telephone;
                    saleList.Add(sale);
                }
            }
            return saleList;
        }
    }

}
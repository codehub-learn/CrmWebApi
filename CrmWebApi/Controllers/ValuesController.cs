using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelCrm.Models;
using ModelCrm.Options;
using ModelCrm.Services;

namespace CrmWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("customers")]
        public List<Customer> GetAllCustomers()
        {
            CustomerCrud customerService = new CustomerCrud();
            List<Customer> customers = customerService.GetAllCustomers();
            return customers;
        }

        [HttpGet("customers/{id}")]
        public  Customer  GetOneCustomers(int id)
        {
            CustomerCrud customerService = new CustomerCrud();
            Customer customer = customerService.GetCustomerById(id);
            return customer;
        }

        [HttpPost("customers")]
        public Customer AddCustomer(CustomerOptions customerOpt)
        { 
            CustomerCrud customerService = new CustomerCrud();
         return   customerService.CreateCustomer(customerOpt);
            
        }

        [HttpPut("customers/{id}")]
        public Customer UpdateCustomer(CustomerOptions customerOpt, int id)
        {
            CustomerCrud customerService = new CustomerCrud();
            return customerService.UpdateCustomer(customerOpt, id);

        }



    }
}

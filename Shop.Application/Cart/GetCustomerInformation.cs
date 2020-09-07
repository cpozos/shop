﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Shop.Application.Cart
{
   public class GetCustomerInformation
   {
      private ISession _session;

      public GetCustomerInformation(ISession session)
      {
         _session = session;
      }

      public Request Do()
      {
         var stringObject = _session.GetString("customer-info");

         if(string.IsNullOrWhiteSpace(stringObject))
            return null;

         return JsonConvert.DeserializeObject<Request>(stringObject);
      }

      public class Request
      {
         public string FirstName { get; set; }
         public string SecondName { get; set; }
         public string LastName { get; set; }
         public string Email { get; set; }
         public string PhoneNumber { get; set; }
         public string Address1 { get; set; }
         public string Address2 { get; set; }
         public string City { get; set; }
         public string PostCode { get; set; }
      }
   }
}

using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SportsStore.Infrastructure;

namespace SportsStore.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services){
            ISession sesion = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart car = sesion?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            car.Session = sesion;
            return car;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Product product, int quantity){
            base.AddItem(product, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveLine(Product product){
            base.RemoveLine(product);
            Session.SetJson("Cart", this);
        }

        public override void Clear() {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
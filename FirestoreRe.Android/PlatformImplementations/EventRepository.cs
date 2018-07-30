using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirestoreRe.Droid.Services;
using FirestoreRe.Repositories;
using FirestoreRe.Models.DataObjects;
using FirestoreRe.Droid.Extensions;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirestoreRe.Droid.PlatformImplementations.EventRepository))]
namespace FirestoreRe.Droid.PlatformImplementations
{
    public class EventRepository : IRepository<Event>
    {
        public IEnumerable<Event> GetAll()
        {
            return this.GetAllAsync().Result;
        }

        public Task<IEnumerable<Event>> GetAllAsync()
        {
            return FirestoreService.Instance
                                   .Collection("events")
                                   .Document("public")
                                   .Collection("resources")
                                   .GetCollectionAsync<Event>();
        }

        public Event GetOne(string id)
        {
            return this.GetOneAsync(id).Result;
        }

        public Task<Event> GetOneAsync(string id)
        {
            return FirestoreService.Instance
                                   .Collection("events")
                                   .Document("public")
                                   .Collection("resources")
                                   .Document(id)
                                   .GetDocumentAsync<Event>();
        }
    }
}

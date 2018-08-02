using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirestoreRe.iOS.Extensions;
using FirestoreRe.iOS.Services;
using FirestoreRe.Models.DataObjects;
using FirestoreRe.Repositories;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirestoreRe.iOS.PlatformImplementations.EventRepository))]
namespace FirestoreRe.iOS.PlatformImplementations
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
                                   .GetCollection("events")
                                   .GetDocument("public")
                                   .GetCollection("resources")
                                   .GetCollectionAsync<Event>();
        }

        public Event GetOne(string id)
        {
            return this.GetOneAsync(id).Result;
        }

        public Task<Event> GetOneAsync(string id)
        {
            return FirestoreService.Instance
                                   .GetCollection("events")
                                   .GetDocument("public")
                                   .GetCollection("resources")
                                   .GetDocument(id)
                                   .GetDocumentAsync<Event>();
        }
    }
}

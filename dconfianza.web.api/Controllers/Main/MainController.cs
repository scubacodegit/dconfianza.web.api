using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using dconfianza.Web.Api.Models.Main.Interface;
using dconfianza.Entity;


namespace dconfianza.Web.Api.Controllers.Main
{
    public class MainController : ApiController
    {
        private readonly IMain repository;
        
        public MainController(IMain repository)
        {
            this.repository = repository;
        }

        #region Gets
                
        public List<Location> GetLocations()
        {
            return repository.SelectLocation();
        }

        [HttpGet, ActionName("getservices")]
        public List<Service> SelectServices()
        {
            return repository.SelectServices();
        }

        [HttpGet, ActionName("getservicesbylocation")]
        public List<Service> SelectServiceByLocationID(int locationID)
        {
            return repository.SelectServiceByLocationID(locationID);
        }

        [HttpGet, ActionName("getactiveworkers")]
        public List<Worker> SelectActiveWorkersByLocationAndService(int locationID, int serviceID)
        {
            return repository.SelectActiveWorkersByLocationAndService(locationID, serviceID);
        }

        [HttpGet, ActionName("getworker")]
        public Worker SelectWorkerByID(int workerID)
        {
            return repository.SelectWorkerByID(workerID);
        }

        [HttpGet, ActionName("getworkerreviews")]
        public List<WorkerReview> SelectWorkerReviews(int workerID)
        {
            return repository.SelectWorkerReviews(workerID);
        }

        [HttpPost, ActionName("addreview")]
        public HttpResponseMessage WorkerReviewInsert(WorkerReview review)
        {
            int workerReviewID = repository.WorkerReviewInsert(review.CreatedByID, review.WorkerID, review.Review, review.Rating);
            var response = Request.CreateResponse<int>(HttpStatusCode.Created, workerReviewID);
            //TODO: locatoin variable is wrong
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("/api/main/review/{0}", workerReviewID.ToString()));
            return response;
        }

        [HttpPost, ActionName("addworker")]
        public HttpResponseMessage WorkerInsert(int userID, Worker worker )
        {
            int workerID = repository.WorkerInsert(worker.FirstName, worker.LastName, worker.MobilPhone, worker.WorkPhone, worker.Email, worker.LocationID, worker.ServiceID, userID);
            var response = Request.CreateResponse<int>(HttpStatusCode.Created, workerID);            
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("/api/main/getworker?workerID={0}", workerID.ToString()));
            return response;
        }

        [HttpPost, ActionName("addmessage")]
        public HttpResponseMessage  ContactMessageInsert(ContactMessage message)
        {
            int contactMessageID = repository.ContactMessageInsert(message.UserID, message.Email, message.Message);
            var response = Request.CreateResponse<int>(HttpStatusCode.Created, contactMessageID);
            response.Headers.Location = new Uri(Request.RequestUri, string.Format("/api/main/getmessage?messageID={0}", contactMessageID.ToString()));
            return response;
        }
        #endregion

    }
}
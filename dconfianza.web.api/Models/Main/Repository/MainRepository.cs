using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dconfianza.Web.Api.Models.Main.Interface;
using dconfianza.Entity;
using dconfianza.Model;

namespace dconfianza.Web.Api.Models.Main.Repository
{
    public class MainRepository : IMain
    {
        public MainRepository()
        {

        }

        public List<Location> SelectLocation()
        {
            List<Location> list = null;
            using (var context = new dconfianzaEntities())
            {
                List<spLocationSelectAll_Result> result =context.spLocationSelectAll().ToList();
                if (result != null)
                {
                    list = new List<Location>();
                    foreach (spLocationSelectAll_Result item in result)
                    {
                        Location location = new Location();
                        location.ID = item.LocationID;
                        location.Name = item.LocationName;
                        list.Add(location);
                    }

                }
            }

            return list;
        }

        public List<Service> SelectServices()
        {
            List<Service> list = null;
            using (var context = new dconfianzaEntities())
            {
                List<spServiceSelectAll_Result> result = context.spServiceSelectAll().ToList();
                if (result != null)
                {
                    list = new List<Service>();
                    foreach (spServiceSelectAll_Result item in result)
                    {
                        Service service = new Service();
                        service.ID = item.ServiceID;
                        service.Name = item.ServiceName;
                        list.Add(service);
                    }
                }
            }

            return list;
        }

        public List<Service> SelectServiceByLocationID(int locationID)
        {
            List<Service> list = null;
            using (var context = new dconfianzaEntities())
            {
                List<spSelectServiceByLocationID_Result> result = context.spSelectServiceByLocationID(locationID).ToList();
                if (result != null)
                {
                    list = new List<Service>();
                    foreach (spSelectServiceByLocationID_Result item in result)
                    {
                        Service service = new Service();
                        service.ID = item.ServiceID;
                        service.Name = item.ServiceName;
                        list.Add(service);
                    }

                }
            }

            return list;
        }
        
        public List<Worker> SelectActiveWorkersByLocationAndService(int locationID, int serviceID)
        {
            List<Worker> list = null;
            using (var context = new dconfianzaEntities())
            {
                List<spSelectActiveWorkersByLocationAndService_Result> result = context.spSelectActiveWorkersByLocationAndService(locationID, serviceID).ToList();
                if (result != null)
                {
                    list = new List<Worker>();
                    foreach (spSelectActiveWorkersByLocationAndService_Result item in result)
                    {
                        Worker worker = new Worker();
                        worker.ID = item.WorkerID;
                        worker.FirstName = item.FirstName;
                        worker.LastName = item.LastName;
                        worker.MobilPhone = item.MobilPhone;
                        worker.WorkPhone = item.WorkPhone;
                        worker.Email = item.Email;
                        worker.LocationID = item.LocationID;
                        worker.LocationName = item.LocationName;
                        worker.Rating = item.Rating.Value;
                        worker.Resume = item.Resume;
                        worker.Active = item.Active;
                        worker.CreatedDate = item.CreatedDate;
                        worker.CreatedByID = item.CreatedByID;
                        worker.CreatedByFirstName = item.CreatedByFirstName;
                        worker.CreatedByLastName = item.CreatedByLastName;
                        worker.ServiceID = item.ServiceID;
                        worker.ServiceName = item.ServiceName;
                        list.Add(worker);
                    }
                }
            }

            return list;
        }

        public Worker SelectWorkerByID(int workerID)
        {
            Worker worker = null;
            using (var context = new dconfianzaEntities())
            {                
                spWorkerSelectByID_Result result = context.spWorkerSelectByID(workerID).FirstOrDefault();
                if (result != null)
                {
                    worker = worker = new Worker();
                    worker.ID = result.WorkerID;
                    worker.FirstName = result.FirstName;
                    worker.LastName = result.LastName;
                    worker.MobilPhone = result.MobilPhone;
                    worker.WorkPhone = result.WorkPhone;
                    worker.Email = result.Email;
                    worker.LocationID = result.LocationID;
                    worker.LocationName = result.LocationName;
                    worker.Rating = result.Rating.Value;
                    worker.Resume = result.Resume;
                    worker.Active = result.Active;
                    worker.CreatedDate = result.CreatedDate;
                    worker.CreatedByID = result.CreatedByID;
                    worker.CreatedByFirstName = result.CreatedByFirstName;
                    worker.CreatedByLastName = result.CreatedByLastName;
                    worker.ServiceID = result.ServiceID;
                    worker.ServiceName = result.ServiceName;

                }

            }
            return worker;
        }

        public List<WorkerReview> SelectWorkerReviews(int workerID)
        {
            List<WorkerReview> list = null;
            using (var context = new dconfianzaEntities())
            {
                List<spWorkeReviewSelectByID_Result> result = context.spWorkeReviewSelectByID(workerID).ToList();
                if (result != null)
                {
                    list = new List<WorkerReview>();
                    foreach (spWorkeReviewSelectByID_Result item in result)
                    {
                        WorkerReview workerReview = new WorkerReview();
                        workerReview.ID = item.WorkerReviewID;
                        workerReview.WorkerID = item.WorkerID;
                        workerReview.FirstName = item.FirstName;
                        workerReview.LastName = item.LastName;
                        workerReview.Review = item.Review;
                        workerReview.Rating = item.Rating;
                        workerReview.CreatedDate = item.CreatedDate;
                        workerReview.CreatedByFirstName = item.CreatedByFirstName;
                        workerReview.CreatedByLastName = item.CreatedByLastName;
                        list.Add(workerReview);
                    }                    
                }
            }

            return list;
        }

        public int WorkerReviewInsert(int userID, int workerID, string review, double rating)
        {
            using (var context = new dconfianzaEntities())
            {
                spWorkerReviewInsert_Result result = context.spWorkerReviewInsert(userID, workerID, review, rating).FirstOrDefault();
                return (int)result.WorkerReviewID;
            }
        }

        public int WorkerInsert(String firstName, String lastName, String mobilePhone, String workPhone, String email, int locationID, int serviceID, int userID)
        {
            using (var context = new dconfianzaEntities())
            {
                spWorkerInsert_Result result =  context.spWorkerInsert(firstName, lastName, mobilePhone, workPhone, email, locationID, serviceID, null, userID).FirstOrDefault();
                return (int)result.WorkerID;
            }
        }

        public int ContactMessageInsert(int userID, String email, String message)
        {
            using (var context = new dconfianzaEntities())
            {
                return (int)context.spContacMessageInsert(email, message, userID).FirstOrDefault().ContactMessageID;
            }
              
        }

    }
}
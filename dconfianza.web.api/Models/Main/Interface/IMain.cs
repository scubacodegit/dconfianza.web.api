using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dconfianza.Entity;

namespace dconfianza.Web.Api.Models.Main.Interface
{
    public interface IMain
    {
        List<Location> SelectLocation();
        List<Service> SelectServices();
        List<Service> SelectServiceByLocationID(int locationID);
        List<Worker> SelectActiveWorkersByLocationAndService(int locationID, int serviceID);
        Worker SelectWorkerByID(int workerID);
        List<WorkerReview> SelectWorkerReviews(int workerID);
        int WorkerReviewInsert(int userID, int workerID, string review, double rating);
        int WorkerInsert(String firstName, String lastName, String mobilePhone, String workPhone, String email, int locationID, int serviceID, int userID);
        int ContactMessageInsert(int userID, String email, String message);
    }

}

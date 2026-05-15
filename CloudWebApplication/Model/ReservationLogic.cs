using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ReservationLogic
    {
        public List<Reservation> GetAllReservations()
        {
            ReservationDAO reservationDAO = new ReservationDAO();
            return reservationDAO.GetAllReservations();
        }

        public bool AddNewReservation(int uid, string isbn)
        {
            ReservationDAO reservationDAO = new ReservationDAO();
            return reservationDAO.AddNewReservation(uid, isbn) > 0;
        }
        public List<Reservation> GetReservationByID(int uid)
        {
            ReservationDAO reservationDAO = new ReservationDAO();
            return reservationDAO.GetReservationByID(uid);
        }
        public bool RemoveReservation(int uid, string isbn)
        {
            ReservationDAO dao = new ReservationDAO();
            return dao.DeleteReservation(uid, isbn);
        }

    }
}

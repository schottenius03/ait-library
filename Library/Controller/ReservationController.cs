using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public  class ReservationController
    {
        public List<ReservationDTO> GetAllReservations()
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            ServiceReferenceLibrary.Reservation[] reservations = webService.GetAllReservations();

            List<ReservationDTO> reservationDTOs = new List<ReservationDTO>();

            if (reservations != null)
            {
                foreach (ServiceReferenceLibrary.Reservation reservation in reservations)
                {
                    ReservationDTO dto = new ReservationDTO
                    {
                        RID = reservation.RID,
                        UID = reservation.UID,
                        ISBN = reservation.ISBN,
                        ReservedDate = reservation.ReservedDate
                    };
                    reservationDTOs.Add(dto);
                }
            }

            return reservationDTOs;
        }

        public List<ReservationDTO> GetReservationsByUserID(int uid)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            ServiceReferenceLibrary.Reservation[] reservations = webService.GetReservationByID(uid);

            List<ReservationDTO> reservationDTOs = new List<ReservationDTO>();

            if (reservations != null)
            {
                foreach (ServiceReferenceLibrary.Reservation reservation in reservations)
                {
                    ReservationDTO dto = new ReservationDTO
                    {
                        RID = reservation.RID,
                        UID = reservation.UID,
                        ISBN = reservation.ISBN,
                        ReservedDate = reservation.ReservedDate
                    };
                    reservationDTOs.Add(dto);
                }
            }

            return reservationDTOs;
        }

        public bool AddNewReservation(int uid, string isbn)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            return webService.AddNewReservation(uid, isbn);
        }

        public bool RemoveReservation(int uid, string isbn)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            return webService.RemoveReservation(uid, isbn);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataSetBookTableAdapters;

namespace Model
{
    public class ReservationDAO
    {
        public List<Reservation> GetAllReservations()
        {
            try
            {
                TabReservedTableAdapter tabReservedTableAdapter = new TabReservedTableAdapter();
                DataSetBook.TabReservedDataTable table = tabReservedTableAdapter.GetData();

                if (table == null || table.Count == 0)
                {
                    return new List<Reservation>();
                }

                List<Reservation> reservations = new List<Reservation>();
                foreach (DataRow row in table.Rows)
                {
                    reservations.Add(new Reservation
                    {
                        RID = Convert.ToInt32(row["RID"]),
                        UID = Convert.ToInt32(row["UID"]),
                        ISBN = row["ISBN"].ToString(),
                        ReservedDate = Convert.ToDateTime(row["ReservedDate"])
                    });
                }

                return reservations;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllReservations: {ex.Message}");
                return new List<Reservation>();
            }
        }

        public int AddNewReservation(int uid, string isbn)
        {
            try
            {
                TabReservedTableAdapter tabReservedTableAdapter = new TabReservedTableAdapter();
                return tabReservedTableAdapter.AddNewReservation(uid, isbn);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddNewReservation: {ex.Message}");
                return -1;
            }
        }

        public List<Reservation> GetReservationByID(int uid)
        {
            try
            {
                TabReservedTableAdapter tabReservedTableAdapter = new TabReservedTableAdapter();
                DataSetBook.TabReservedDataTable table = tabReservedTableAdapter.GetReservationByID(uid);

                if (table == null || table.Count == 0)
                {
                    return new List<Reservation>();
                }

                List<Reservation> reservations = new List<Reservation>();
                foreach (DataRow row in table.Rows)
                {
                    reservations.Add(new Reservation
                    {
                        RID = Convert.ToInt32(row["RID"]),
                        UID = Convert.ToInt32(row["UID"]),
                        ISBN = row["ISBN"].ToString(),
                        ReservedDate = Convert.ToDateTime(row["ReservedDate"]),
                    });
                }

                return reservations;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetReservationByID: {ex.Message}");
                return new List<Reservation>();
            }
        }

        public bool DeleteReservation(int uid, string isbn)
        {
            try
            {
                TabReservedTableAdapter adapter = new TabReservedTableAdapter();
                int rowsAffected = adapter.DeleteReservation(uid, isbn); // Make sure implemented in TableAdapter
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteReservation: {ex.Message}");
                return false;
            }
        }


    }
}

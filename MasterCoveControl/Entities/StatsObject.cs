using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterCoveControl.Entities
{
    public class StatsObject
    {
        public int ReferencesTotal { get; set; }
        public int ReferencesFull { get; set; }
        public int ReferencesUnfull { get; set; }
        public int ReferencesWrong { get; set; }

        public int AcusesFull { get; set; }
        public int AcusesUnfull { get; set; }
        public int AcusesWrong { get; set; }
        public int AcusesEmpty { get; set; }

        public int DetailsFull { get; set; }
        public int DetailsUnfull { get; set; }
        public int DetailsWrong { get; set; }
        public int DetailsEmpty { get; set; }

        public StatsObject()
        {
            ReferencesTotal = 0;
            ReferencesFull = 0;
            ReferencesUnfull = 0;
            ReferencesWrong = 0;
            AcusesFull = 0;
            AcusesUnfull = 0;
            DetailsFull = 0;
            DetailsUnfull = 0;
        }

        public void AddStats(string stateGeneral, string stateAcuse, string stateDetail)
        {
            ReferencesTotal++;

            switch (stateGeneral)
            {
                case States.Complete:
                    ReferencesFull++;
                    break;
                case States.Incomplete:
                    ReferencesUnfull++;
                    break;
                case States.Wrong:
                    ReferencesWrong++;
                    break;
                default:
                    ReferencesUnfull++;
                    break;
            }

            switch (stateAcuse)
            {
                case States.Complete:
                    AcusesFull++;
                    break;
                case States.Incomplete:
                    AcusesUnfull++;
                    break;
                case States.Wrong:
                    AcusesWrong++;
                    break;
                case States.Empty:
                    AcusesUnfull++;
                    break;
                default:
                    AcusesEmpty++;
                    break;
            }

            switch (stateDetail)
            {
                case States.Complete:
                    DetailsFull++;
                    break;
                case States.Incomplete:
                    DetailsUnfull++;
                    break;
                case States.Wrong:
                    DetailsWrong++;
                    break;
                case States.Empty:
                    DetailsUnfull++;
                    break;
                default:
                    DetailsEmpty++;
                    break;
            }
        }
    }
}

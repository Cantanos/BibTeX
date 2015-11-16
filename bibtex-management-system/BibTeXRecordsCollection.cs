using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibtex_management_system
{
    class BibTeXRecordsCollection
    {
        List<BibTeXRecord> records;

        public BibTeXRecordsCollection()
        {
            this.records = new List<BibTeXRecord>();
        }

        public BibTeXRecordsCollection(List<BibTeXRecord> records)
        {
            this.records = new List<BibTeXRecord>(records);
        }

        public void setRecords(List<BibTeXRecord> records)
        {
            this.records = new List<BibTeXRecord>(records);
        }

        public List<BibTeXRecord> getRecords()
        {
            return this.records;
        }

        public BibTeXRecord getRecordByID(string id)
        {
            BibTeXRecord result = new BibTeXRecord();
            foreach (BibTeXRecord e in records)
            {
                if (id.Equals(e.ID))
                {
                    result = e;
                    return result;
                }
            }
            return result;
        }

        public void addRecord(BibTeXRecord newRecord)
        {
            this.records.Add(newRecord);
        }

        public void addRecords(List<BibTeXRecord> newRecords)
        {
            this.records.AddRange(newRecords);
        }
    }
}

using Layered_BP.PurchaseHistory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layered_BP.Service
{
    class HistoryService
    {
        private readonly HistoryRepository _repository;
        public List<History> History;

        public HistoryService()
        {
            _repository = new HistoryRepository();
            History = _repository.GetAll();
        }

        public void AddRecord(History record)
        {
            History.Add(record);
            _repository.SaveAll(History);
        }

        public void SaveAll()
        {
            _repository.SaveAll(History);
        }

        public List<History> GetAllHistory()
        {
            return History;
        }

        // =================== history by user
        public List<History> GetByUser(int userID)
        {
            List<History> result = new List<History>();
            foreach (History h in History)
            {
                if (h.UserID == userID)
                    result.Add(h);
            }
            return result;
        }

    }
}

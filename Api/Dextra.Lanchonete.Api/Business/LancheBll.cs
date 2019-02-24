using System.Collections.Generic;
using Dextra.Lanchonete.Api.Models;
using Dextra.Lanchonete.Api.Repository;

namespace Dextra.Lanchonete.Api.Business
{
    public class LancheBll : ILancheBll
    {
        private readonly ILancheRepository _lancheRepository;
        public LancheBll (ILancheRepository lancheRepository) {
            _lancheRepository = lancheRepository;
        }

        public void Add(Lanche lanche)
        {
            _lancheRepository.Add(lanche);
        }

        public Lanche Find(int id)
        {
            return _lancheRepository.Find(id);
        }

        public IEnumerable<Lanche> GetAll()
        {
            return _lancheRepository.GetAll();
        }

        public void Remove(int id)
        {
            _lancheRepository.Remove(id);
        }

        public void Update(Lanche lanche)
        {
            _lancheRepository.Update(lanche);
        }
    }
}
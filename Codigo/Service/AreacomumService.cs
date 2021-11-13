﻿using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AreacomumService : IAreacomumService
    {

        private readonly CondoTechContext _context;


        public AreacomumService(CondoTechContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Editar area comum na base de dados
        /// </summary>
        /// <param name="areacomum">dados da area comum</param>
        public void Update(Areacomum areacomum)
        {
            _context.Update(areacomum);
            _context.SaveChanges();
        }

        /// <summary>
        /// busca por area comum na base de dados
        /// </summary>
        /// <param name="idAreacomum">dados da area comum</param>
        /// <returns>retorna a area comum ou nulo quando não for encontrado</returns>
        public Areacomum Get(int idAreacomum)
        {
            var _areacomum = _context.Areacomum.Find(idAreacomum);
            return _areacomum;
        }

        /// <summary>
        /// Insert area comum na base de dados
        /// </summary>
        /// <param name="areacomum">dados da area comum</param>
        /// <returns>retorna o IdAreaComum gerado</returns>
        public int Insert(Areacomum areacomum)
        {
            _context.Add(areacomum);
            _context.SaveChanges();
            return areacomum.IdAreaComum;
        }


        /// <summary>
        /// Remove uma area comum da base de dados
        /// </summary>
        /// <param name="IdAreaComum">a ser removido</param>
        public void Delete(int IdAreaComum)
        {
            var remocaoArea = _context.Areacomum.Find(IdAreaComum);
            _context.Remove(remocaoArea);
            _context.SaveChanges();
        }

        /// <summary>
        /// Valida uma area comum na base de dados
        /// </summary>
        /// <param name="areacomum">a ser validado</param>
        /// <returns>retorna true caso seja validado ou false caso nao seja</returns>


        //apenas para ter algo implementado
        public bool Validar(Areacomum areacomum)
        {
            throw new NotImplementedException();
        }
    }
}
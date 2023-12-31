﻿using HealthClinic_API.Domains;

namespace HealthClinic_API.Interfaces
{
    public interface IConsultaRepository
    {

        void Cadastrar(Consulta consulta);

        void Deletar(Guid id);

        List<Consulta> ListarTodos();

        void Atualizar(Guid id, Consulta consulta);

        List<Consulta> ListarPorPaciente(Guid id);

        List<Consulta> ListarPorMedico(Guid id);

    }
}

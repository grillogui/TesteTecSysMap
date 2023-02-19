using Microsoft.EntityFrameworkCore;
using TesteSysMap.src.modelos;

namespace TesteSysMap.src.contexto
{
    /// <summary>
    /// <para>Resumo: Classe contexto, responsavel por carregar contexto e definir DbSets</para>
    /// <para>Criado por: Guilherme Grillo</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 18/02/2023</para>
    /// </summary>

    public class TesteSysMapContexto : DbContext
    {
        public DbSet<UsuarioModelo> Usuarios { get; set; }
        public DbSet<TarefaModelo> Tarefas { get; set; }

        public TesteSysMapContexto(DbContextOptions<TesteSysMapContexto> opt) : base(opt)
        {

        }

    }
}

using System;
using System.Collections.Generic;
using Doar.Entity.Entities;

namespace Doar.Entity.EntitiesSearch {
    public class UsuarioPesquisa : BaseDominio {
        public List<int> TipoDeUsuario { get; set; }
        public string Nome { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public List<int> Status { get; set; }
        public DateTime? DataCriacaoInicial { get; set; }
        public DateTime? DataCriacaoFinal { get; set; }
        public DateTime? DataAcessoInicial { get; set; }
        public DateTime? DataAcessoFinal { get; set; }
        public List<int> Perfil { get; set; }
        public List<int> PermissaoIncluida { get; set; }
        public List<int> PermissaoExcluida { get; set; }
        public List<int> Consultor { get; set; }
        public List<int> Clientes { get; set; }
        public List<int> Licenca { get; set; }
        public List<int> EmpreendimentoDaLicenca { get; set; }
        public List<int> UsuarioEspecial { get; set; }
        public List<int> AcessoEspecial { get; set; }
        public List<int> NivelAbrangencia { get; set; }
        public List<int> EmpreendimentoAbrangencia { get; set; }
        public List<int> CalAbrangencia { get; set; }
        public List<int> LinhaNegocio { get; set; }
        public List<int> Regional { get; set; }
        public List<int> SegmentoAtuacao { get; set; }
        public List<int> Area { get; set; }
        public List<int> Aviso { get; set; }
    }
}

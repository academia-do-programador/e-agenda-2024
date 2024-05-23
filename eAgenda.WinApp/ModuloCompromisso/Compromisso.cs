using eAgenda.ConsoleApp.Compartilhado;
using eAgenda.WinApp.ModuloContato;

namespace eAgenda.WinApp.ModuloCompromisso
{
    public class Compromisso : EntidadeBase
    {
        public string Assunto { get; set; }

        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraTermino { get; set; }

        public Contato Contato { get; set; }

        public string Local { get; set; }
        public string Link { get; set; }

        public TipoCompromissoEnum TipoCompromisso
        {
            get
            {
                TipoCompromissoEnum tipoSelecionado;

                if (Local.Length > 0)
                    tipoSelecionado = TipoCompromissoEnum.Presencial;
                else
                    tipoSelecionado = TipoCompromissoEnum.Remoto;

                return tipoSelecionado;
            }
        }

        public Compromisso(
            string assunto,
            string local,
            string link,
            DateTime data,
            TimeSpan horaInicio,
            TimeSpan horaTermino,
            Contato contato
        )
        {
            Assunto = assunto;
            Local = local;
            Link = link;
            Data = data;
            HoraInicio = horaInicio;
            HoraTermino = horaTermino;
            Contato = contato;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Assunto.Trim()))
                erros.Add("O campo \"assunto\" é obrigatório");

            if (string.IsNullOrEmpty(Local.Trim()) && string.IsNullOrEmpty(Link.Trim()))
                erros.Add("O campo \"local / link\" é obrigatório");

            if (!string.IsNullOrEmpty(Local.Trim()) && !string.IsNullOrEmpty(Link.Trim()))
                erros.Add("Os campos \"local\" e \"link\" são mutualmente exclusivos, preencha apenas um");

            if (HoraInicio > HoraTermino)
                erros.Add("A hora de início não pode ser depois da hora de término.");

            if (HoraTermino < HoraInicio)
                erros.Add("A hora de término não pode ser antes da hora de início.");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Compromisso atualizado = (Compromisso)novoRegistro;

            Assunto = atualizado.Assunto;
            Local = atualizado.Local;
            Link = atualizado.Link;
            Data = atualizado.Data;
            HoraInicio = atualizado.HoraInicio;
            HoraTermino = atualizado.HoraTermino;
            Contato = atualizado.Contato;
        }

        public override string ToString()
        {
            //string linkOuLocal = TipoCompromisso == TipoCompromissoEnum.Remoto ? Link : Local;

            string nomeContato = Contato == null ? string.Empty : Contato.Nome;

            return $"Id: {Id}, Assunto: {Assunto}, Data: {Data.ToShortDateString()}, Início: {HoraInicio.ToString(@"hh\:mm")}, Término: {HoraTermino.ToString(@"hh\:mm")}, Contato: {nomeContato}, Tipo: {TipoCompromisso.ToString()}";
        }
    }
}

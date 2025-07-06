using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;

namespace WpfFormulierDemo
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<FormulierItem> FormulierItems { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            VulRichTextBox();
            VulItemsControl();
        }

        private void VulRichTextBox()
        {
            var doc = new FlowDocument();
            doc.Blocks.Add(new Paragraph(new Run("Formulier Titel") { TextDecorations = TextDecorations.Underline }));
            doc.Blocks.Add(new Paragraph(new Run("Hoofdstuk 1") { TextDecorations = TextDecorations.Underline }));
            VoegVraagAntwoordToe(doc, "Wat is je naam?", "Jan");
            VoegVraagAntwoordToe(doc, "Wat is je leeftijd?", "30");
            doc.Blocks.Add(new Paragraph(new Run("Hoofdstuk 2") { TextDecorations = TextDecorations.Underline }));
            VoegVraagAntwoordToe(doc, "Wat is je beroep?", "Programmeur");
            FormulierBox.Document = doc;
        }

        private void VoegVraagAntwoordToe(FlowDocument doc, string vraag, string antwoord)
        {
            var p = new Paragraph();
            p.Inlines.Add(new Bold(new Run(vraag + ": ")));
            p.Inlines.Add(new Run(antwoord));
            doc.Blocks.Add(p);
        }

        private void VulItemsControl()
        {
            FormulierItems.Add(new FormulierItem { Tekst = "Formulier Titel", IsTitelOfHoofdstuk = true });
            FormulierItems.Add(new FormulierItem { Tekst = "Hoofdstuk 1", IsTitelOfHoofdstuk = true });
            FormulierItems.Add(new FormulierItem { Tekst = "Wat is je naam?: Jan", IsVraag = true });
            FormulierItems.Add(new FormulierItem { Tekst = "Wat is je leeftijd?: 30", IsVraag = true });
            FormulierItems.Add(new FormulierItem { Tekst = "Hoofdstuk 2", IsTitelOfHoofdstuk = true });
            FormulierItems.Add(new FormulierItem { Tekst = "Wat is je beroep?: Programmeur", IsVraag = true });
        }
    }
}

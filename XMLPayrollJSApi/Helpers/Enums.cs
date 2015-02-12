using System.ComponentModel;
namespace XMLPayrollJSApi.Helpers
{


    public enum TyposAmoibhsKAE : int
    {
        [Description("Βασικός Μισθός")]
        BasikosMisthos = 211,
        [Description("Οικογενειακό Επίδομα")]
        OikogeniakoEpidoma =213,
        [Description("Επίδομα Θέσης")]
        EpidomaTheshs = 227,
        [Description("Επίδομα Προβληματικών Περιοχών")]
        EpidomaProblPerioxwn  = 228,
        [Description("Επίδομα Ειδικής Θέσης")]
        EpidomaEidTheshs = 221,
        [Description("Επίδομα Θέσης")]
        EpidomaTheshs2 = 215,
        [Description("Υπερωρίες εκπαιδευτικών")]
        YperwriesEkpaideutikwn = 516,
        [Description("Επίδομα Προβληματικών Περιοχών")]
        EpidomaProblhmatikwn = 228

    }

    public enum Month : byte
    {
        
        [Description("ΙΑΝΟΥΑΡΙΟΣ")]
        Jan = 1,
        [Description("ΦΕΒΡΟΥΑΡΙΟΣ")]
        Feb = 2,
        [Description("ΜΑΡΤΙΟΣ")]
        Mar = 3,
        [Description("ΑΠΡΙΛΙΟΣ")]
        Apr = 4,
        [Description("ΜΑΙΟΣ")]
        May = 5,
        [Description("ΙΟΥΝΙΟΣ")]
        Jun = 6,
        [Description("ΙΟΥΛΙΟΣ")]
        Jul = 7,
        [Description("ΑΥΓΟΥΣΤΟΣ")]
        Aug = 8,
        [Description("ΣΕΠΤΕΜΒΡΙΟΣ")]
        Sep = 9,
        [Description("ΟΚΤΩΒΡΙΟΣ")]
        Oct = 10,
        [Description("ΝΟΕΜΒΡΙΟΣ")]
        Nov = 11,
        [Description("ΔΕΚΕΜΒΡΙΟΣ")]
        Dec = 12
    }

    /// <summary>
    /// Περιέχει τις δυνατές τιμές του attribute type του στοιχειου income
    /// Στηρίζεται στο pdf της ΕΑΠ και αντιστοιχεί στον "Τύπο πληρωμής"
    /// </summary>
    public enum TyposEisodhmatos : byte
    {
        [VocativeDescription("Τακτ. Μισθοδοσιας")]
        TaktikesApodoxes = 0,
        [VocativeDescription("Αναδρομικου")]
        Anadromika = 1,
        [VocativeDescription("Τριμηνων Αποδοχων")]
        TrimhnesApodoxes = 2,
        [VocativeDescription("Εκπαιδευτικων Αποδοχων")]
        EkpaidApodoxes = 3,
        [VocativeDescription("Αποζημιωσης")]
        Apozhmiwsh = 4,
        [VocativeDescription("Αποζημιωσης Αδειας")]
        ApozhmiwshAdeias = 5,
        [VocativeDescription("Ετεροχρονισμενη")]
        Eteroxronismenh = 6
    }

    
    /// <summary>
    /// Enum με ολους τους φορεις κράτησης
    /// </summary>
    public enum ForeisKrathshs
    {
        [Description("Φόρος Εισοδήματος Κλίμακας")]
        ForeaskratID_3011300=3011300,
        [Description("Εισφορά 8% (Ν.Δ. 3896/58 & 78/73) - ΤΣΚΥ")]
        ForeaskratID_3082200=3082200,
        [Description("Κλάδος Σύνταξης")]
        ForeaskratID_3082400=3082400,
        [Description("Αναγνώριση Προϋπηρεσίας")]
        ForeaskratID_3082500=3082500,
        [Description("Εισφορά (2%) για καταπολέμηση της ανεργίας")]
        ForeaskratID_3082800=3082800,
        [Description("Έσοδα από έκτακτη εισφ & ειδική εισφ αλληλεγγύης")]
        ForeaskratID_3089100=3089100,
        [Description("Επιστροφές αποδοχών")]
        ForeaskratID_3324100=3324100,
        [Description("Απεργία / Στάση εργασίας")]
        ForeaskratID_3324300=3324300,
        [Description("ΠΕΙΘΑΡΧΙΚΟ ΠΡΟΣΤΙΜΟ")]
        ForeaskratID_3373900=3373900,
        [Description("Γεωτεχνικό Επιμελητήριο Ελλάδος")]
        ForeaskratID_4000300=4000300,
        [Description("Ενιαίος Δημοσιογραφικός Οργανισμός Επικουρικής Ασφάλισης & Περίθαλψης")]
        ForeaskratID_4000700=4000700,
        [Description("Ενωση Ελλήνων Χημικών")]
        ForeaskratID_4000800=4000800,
        [Description("Ι.Κ.Α")]
        ForeaskratID_4002100=4002100,
        [Description("Κλάδος Επικουρικής Ασφάλισης Δικηγόρων")]
        ForeaskratID_4002200=4002200,
        [Description("Μ.Τ.Π.Υ Τακτικές Κρατήσεις - Δάνεια")]
        ForeaskratID_4003101=4003101,
        [Description("Μετοχικό Ταμείο Πολιτικών Υπαλλήλων (82984)")]
        ForeaskratID_4003102=4003102,
        [Description("Μετοχικό Ταμείο Πολιτικών Υπαλλήλων (82983)")]
        ForeaskratID_4003103=4003103,
        [Description("Μετοχικό Ταμείο Πολιτικών Υπαλλήλων (82982)")]
        ForeaskratID_4003107=4003107,
        [Description("Μετοχικό Ταμείο Πολιτικών Υπαλλήλων (82985)")]
        ForeaskratID_4003108=4003108,
        [Description("Μετοχικό Ταμείο Πολιτικών Υπαλλήλων (82986)")]
        ForeaskratID_4003109=4003109,
        [Description("Ναυτικό Απομαχικό Ταμείο")]
        ForeaskratID_4003300=4003300,
        [Description("Οργανισμός Διαχείρισης Δημόσιου Υλικού")]
        ForeaskratID_4003700=4003700,
        [Description("Ταχυδρομικό Ταμιευτήριο")]
        ForeaskratID_4008300=4008300,
        [Description("ΗΣΑΠ ΥΓΕΙΟΝΟΜΙΚΗ")]
        ForeaskratID_4009000=4009000,
        [Description("Ταμείο Νομικών")]
        ForeaskratID_4009301=4009301,
        [Description("Ταμείο Νομικών Με Έμμισθη Εντολή")]
        ForeaskratID_4009304=4009304,
        [Description("Ταμείο Αρωγής Μονίμων Πολιτικών Υπαλ. ΥΕΘΑ")]
        ForeaskratID_4009400=4009400,
        [Description("Ταμείο Ασφάλισης Ξενοδοχοϋπαλλήλων")]
        ForeaskratID_4009600=4009600,
        [Description("Ταμείο Πρόνοιας Εργατοϋπαλλήλων Μετάλλου")]
        ForeaskratID_4010100=4010100,
        [Description("ΤΑΥΤΕΚΩ (πρώην Τ.Α.Π.ΟΤΕ  Ασθένειας)")]
        ForeaskratID_4010400=4010400,
        [Description("Τομέας Πρόνοιας Προσωπικού Ο.Τ.Ε.")]
        ForeaskratID_4010700=4010700,
        [Description("ΙΚΑ ΕΤΑΜ Τοπικό Υποκατάστημα Ασφ. Κλάδου Σύνταξης ΤΑΠ-ΟΤΕ Σύνταξης")]
        ForeaskratID_4010800=4010800,
        [Description("Ε.Τ.Α.Α. (Τομέας Υγείας Δικηγόρων Αθηνών)")]
        ForeaskratID_4011500=4011500,
        [Description("Τ.Ε.Α.Δ.Υ")]
        ForeaskratID_4012501=4012501,
        [Description("Ταμείο Επικουρικής Ασφάλισης Δημοσίων Υπαλλλήλων")]
        ForeaskratID_4012502=4012502,
        [Description("Ταμείο Επικουρικής Ασφάλισης Δημοσίων Υπαλλλήλων")]
        ForeaskratID_4012503=4012503,
        [Description("ΤΕΑΔΥ Πρόσθετων Αποδοχών")]

        ForeaskratID_4012504=4012504,
        [Description("Ταμείο Επικουρικής Ασφάλισης Δημοσίων Υπαλλλήλων")]
        ForeaskratID_4012505=4012505,
        [Description("Κράτηση δόσεων δανείου υπέρ Τ.Ε.Α.Δ.Υ.")]
        ForeaskratID_4012507=4012507,
        [Description("Τ.Ε.Α.Δ.Υ.-Τ.Ε.Α.Π.Ο.Κ.Α. Παλαιοί Ασφαλισμένοι")]
        ForeaskratID_4012907=4012907,
        [Description("Τ.Ε.Α.Δ.Υ.-Τ.Ε.Α.Π.Ο.Κ.Α. Νέοι Ασφαλισμένοι")]
        ForeaskratID_4012908=4012908,
        [Description("Ταμ. Επικουρ. Ασφαλ.-Προν. Προσ. ΕΡΤ -Τουρισμ. (Ασθενείας-Σύνταξης)")]
        ForeaskratID_4013000=4013000,
        [Description("Ταμείο Επικουρικής Ασφάλισης Χημικών")]
        ForeaskratID_4013400=4013400,
        [Description("Ταμείο Παρακαταθηκών & Δανείων")]
        ForeaskratID_4013500=4013500,
        [Description("Τ.Π.Δ.Υ")]
        ForeaskratID_4013601=4013601,
        [Description("Τομέας Πρόνοιας Δημοσίων Υπαλλήλων")]
        ForeaskratID_4013604=4013604,
        [Description("Τ.Π.Δ.Υ (ΕΙΔΙΚΗ ΕΙΣΦΟΡΑ 1% Ν.3986/2011)")]
        ForeaskratID_4013605=4013605,
        [Description("Ταμείο Πρόνοιας Προσωπικού ΟΣΕ")]
        ForeaskratID_4014001=4014001,
        [Description("ΕΤΑΑ – Τομέας Σύνταξης Υγειονομικών")]
        ForeaskratID_4014201=4014201,
        [Description("ΕΤΑΑ – Τομέας Υγείας Υγειονομικών")]
        ForeaskratID_4014202=4014202,
        [Description("ΕΤΑΑ-Στέγη Υγειονομικών")]
        ForeaskratID_4014204=4014204,
        [Description("ΕΤΑΑ - Τομέας Πρόνοιας Υγειονομικών")]
        ForeaskratID_4014205=4014205,
        [Description("ΗΣΑΠ ΣΥΝΤΑΞΗ")]
        ForeaskratID_4014300=4014300,
        [Description("Τομέας Σύνταξης Προσωπικού Ημερησίων Εφημερίδων Αθηνών και Θεσσαλονίκης")]
        ForeaskratID_4014500=4014500,
        [Description("Ταμείο Υγείας Δημοτικών & Κοινοτικών Υπαλλήλων")]
        ForeaskratID_4014700=4014700,
        [Description("Σύλλογος Μονίμων Υπαλλήλων Γεν. Γραμ. Λαϊκής Επιμόρφωσης")]
        ForeaskratID_4016800=4016800,
        [Description("Ταμείο Επικ. Ασφάλισης Εκπαιδ/κών Ιδιωτικής Γεν. Εκπαίδευσης")]
        ForeaskratID_4023200=4023200,
        [Description("Α.Δ.Ε.Δ.Υ.")]
        ForeaskratID_4027100=4027100,
        [Description("Λογαριασμός Ανεργίας Προσωπικού Ημερησίων Εφημερίδων Αθηνών και Θεσσαλονίκης")]
        ForeaskratID_4027400=4027400,
        [Description("Ταμείο Συντάξεως Μηχ. Εργολάβων Δημ. Έργων")]
        ForeaskratID_4033500=4033500,
        [Description("Ταμείο Συντάξεως Μηχ. Εργολάβων Δημ. Έργων")]
        ForeaskratID_4033701=4033701,
        [Description("Ταμείο Συντάξεως Μηχ. Εργολάβων Δημ. Έργων")]
        ForeaskratID_4033800=4033800,
        [Description("Ταμείο Συντάξεως Μηχ. Εργολάβων Δημ. Έργων")]
        ForeaskratID_4033900=4033900,
        [Description("Ταμείο Συντάξεως Μηχ. Εργολάβων Δημ. Έργων")]
        ForeaskratID_4034000=4034000,
        [Description("Ταχυδρομικό Ταμιευτήριο Καταναλωτικό Δάνειο")]
        ForeaskratID_4035501=4035501,
        [Description("Τομέας Πρόνοιας Υπαλλήλων Νομικών Προσώπων Δημοσίου Δικαίου (Πρώην Ν.103/75)")]
        ForeaskratID_4036300=4036300,
        [Description("Τομέας Πρόνοιας Υπαλλήλων Νομικών Προσώπων Δημοσίου Δικαίου (Πρώην Ν.103/75) (ΕΙΔΙΚΗ ΕΙΣΦΟΡΑ 1% Ν.3986/2011)")]
        ForeaskratID_4036304=4036304,
        [Description("Τ.Ε.Α.Δ.Υ.- Τομέας Ασφάλισης Δημοτικών & Κοινοτικών Υπαλλήλων")]
        ForeaskratID_4038702=4038702,
        [Description("ΤΠΔΥ – ΤΠΔΚΥ (Παλιά εφαρμογή ΤΠΔΥ-ΤΑΔΚΥ, Κράτηση πρόνοιας 1% όλων των παλαιών ασφαλισμένων)")]
        ForeaskratID_4038803=4038803,
        [Description("ΤΠΔΥ - ΤΠΔΚΥ (Παλιά εφαρμογή ΤΠΔΥ-ΤΑΔΚΥ, ΕΙΔΙΚΗ ΕΙΣΦΟΡΑ 1% Ν.3986/2011)")]
        ForeaskratID_4038808=4038808,
        [Description("ΤΕΑΔΥ Τομέας Επικουρ. Ασφαλ. Μισθωτών Ν.Π.Δ.Δ")]
        ForeaskratID_4040901=4040901,
        [Description("Ομοσπονδία Λειτουργών Μέσης Εκπαίδευσης")]
        ForeaskratID_4044700=4044700,
        [Description("Δ.Ο.Ε. (Διδασκαλική Ομοσπονδία Ελλάδας)")]
        ForeaskratID_4051400=4051400,
        [Description("Ειδική εισφορά 1% υπέρ ΟΑΕΔ (αρθ. 38, παρ. 2, Ν. 3986/2011)")]
        ForeaskratID_4051700=4051700,
        [Description("Ο.Π.Α.Δ")]
        ForeaskratID_4052000=4052000,
        [Description("ΤΑΥΤΕΚΩ-ΤΑΠΟΤΕ ΧΡΗΜΑ")]
        ForeaskratID_4054901=4054901,
        [Description("ΤΑΥΤΕΚΩ-ΕΙΣΦΟΡΕΣ ΕΟΠΥΥ (ΤΑΠ-ΟΤΕ)")]
        ForeaskratID_4055001=4055001,
        [Description("Προσωπικά Δάνεια Υπαλλήλων ΟΑΕΔ")]
        ForeaskratID_4056000=4056000,
        [Description("ΕΝΩΣΗ ΥΠΑΛΛΗΛΩΝ ΠΕΡΙΦΕΡΕΙΑΚΩΝ ΥΠΗΡΕΣΙΩΝ ΥΠΕΠΘ ΜΑΚΕΔΟΝΙΑΣ - ΘΡΑΚΗΣ")]
        ForeaskratID_4056100=4056100,
        [Description("Σύλλογος Υπαλλήλων Περιφερειακών Υπηρεσιών Υπουργείου Παιδείας")]
        ForeaskratID_4059100=4059100,
        [Description("Τελωνείο Πατρών")]
        ForeaskratID_4060000=4060000,
        [Description("Κρατήσεις υπέρ οικείων συλλόγων και λοιπών διατάξεων")]
        ForeaskratID_4999999=4999999,
        [Description("Κατάσχεση")]
        ForeaskratID_5000100=5000100,
        [Description("Διατροφή")]
        ForeaskratID_5000200=5000200

    }


}

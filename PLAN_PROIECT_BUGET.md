# Proiect: Planificator de Buget Personal (.NET MAUI)

**Document Arhitectural și Plan de Acțiune**

Acest document descrie viziunea, arhitectura și planul de dezvoltare pentru o aplicație de planificare a bugetului personal.

- **Tehnologie:** .NET MAUI cu C#
- **Arhitectură:** MVVM (Model-View-ViewModel)
- **Bază de date:** SQLite (locală, pe dispozitiv)
- **Platforme Țintă:** Windows, macOS (cu potențial de extindere la Android/iOS)
- **Echipă:** 2 Developeri

---

### **Arhitectura MVVM: O Privire de Ansamblu**

Vom folosi arhitectura **MVVM**, care este standardul în .NET MAUI. Aceasta ne ajută să separăm logica de interfața grafică, făcând codul mai curat și mai ușor de testat.

- **Model (M):** Reprezintă datele aplicației. Sunt clase simple C# (ex: `Transaction`, `Category`) care nu știu nimic despre cum sunt afișate.
- **View (V):** Reprezintă interfața grafică (UI). Este ceea ce vede utilizatorul, definit în fișiere **XAML** (ex: `TransactionsPage.xaml`). View-ul este "prost", el doar afișează date și trimite acțiunile utilizatorului (click-uri) către ViewModel.
- **ViewModel (VM):** Este creierul fiecărei vederi. Este o clasă C# (ex: `TransactionsViewModel.cs`) care pregătește datele din Model pentru a fi afișate în View și conține logica pentru acțiunile utilizatorului.

### **Rolurile Developerilor**

Deși rolurile se vor suprapune, pentru a avea un focus clar, propun următoarea împărțire:

- **Dev 1 (Core & Data Layer):** Se va concentra pe fundația aplicației.
  - **Responsabilități:** Definirea **Modelelor**, interacțiunea cu baza de date (serviciile de date), și logica de business care nu este direct legată de UI.
- **Dev 2 (UI & ViewModel Layer):** Se va concentra pe experiența utilizatorului.
  - **Responsabilități:** Crearea **View**-urilor în XAML, implementarea **ViewModel**-urilor, gestionarea stării paginilor și asigurarea unei interfețe intuitive.

---

## Capitolul 1: Fundația Proiectului și Prima Listă

**Obiectiv:** Crearea scheletului aplicației și afișarea unei liste de date simulate. La finalul acestui capitol, veți avea o aplicație care rulează și afișează ceva, un succes major pentru moral!

#### **Task-uri Comune:**
1.  **Setup Mediu:** Instalați JetBrains Rider (sau VS Code cu C# Dev Kit) și .NET SDK.
2.  **Creare Proiect:** Creați un proiect nou de tip ".NET MAUI App".
3.  **Creare Repository Git:** Inițializați un repository pe GitHub și invitați-vă reciproc.

#### **Task-uri Dev 1 (Core & Data):**
1.  **Definire Modele:** În folderul `Models`, creați clasele C#:
    - `Transaction.cs` (`Guid Id`, `decimal Amount`, `string Description`, `DateTime Date`, `Guid CategoryId`)
    - `Category.cs` (`Guid Id`, `string Name`, `string Color`)
2.  **Creare Serviciu de Date Simulat:** În folderul `Services`, creați `TransactionService.cs`. Implementați o metodă `GetTransactions()` care returnează o listă `List<Transaction>` cu 3-4 tranzacții create manual în cod ("hardcodate").

#### **Task-uri Dev 2 (UI & ViewModel):**
1.  **Creare Pagini:** Creați două pagini noi de tip `.NET MAUI ContentPage (XAML)`:
    - `DashboardPage.xaml`
    - `TransactionsPage.xaml`
2.  **Navigare cu Shell:** Modificați `AppShell.xaml` pentru a adăuga două tab-uri în partea de jos a aplicației care navighează către cele două pagini create.
3.  **Creare ViewModel:** În folderul `ViewModels`, creați `TransactionsViewModel.cs`.
4.  **Afișare Listă:**
    - În `TransactionsPage.xaml`, adăugați un `CollectionView` pentru a afișa lista de tranzacții.
    - În `TransactionsViewModel.cs`, apelați serviciul creat de Dev 1 pentru a obține datele.
    - Folosiți **Data Binding** pentru a lega lista de tranzacții din ViewModel de `CollectionView` din View.

**Criteriu de succes:** Aplicația pornește, afișează două tab-uri jos, iar în pagina de tranzacții apare lista de date simulate.

---

## Capitolul 2: Funcționalități de Bază (CRUD)

**Obiectiv:** A face aplicația interactivă. Utilizatorul va putea adăuga, vizualiza și șterge tranzacții. Datele vor fi salvate într-o bază de date locală.

#### **Task-uri Dev 1 (Core & Data):**
1.  **Integrare Bază de Date:** Adăugați pachetul NuGet `sqlite-net-pcl` în proiect.
2.  **Creare Serviciu Bază de Date:** Creați un `DatabaseService.cs` care se va ocupa de:
    - Inițializarea bazei de date și crearea tabelelor (`Transactions`, `Categories`).
    - Metode pentru `Get`, `Add`, `Update`, `Delete` pentru tranzacții.
3.  **Actualizare Serviciu de Tranzacții:** Modificați `TransactionService.cs` pentru a folosi `DatabaseService` în loc de datele simulate.

#### **Task-uri Dev 2 (UI & ViewModel):**
1.  **Pagină de Adăugare/Editare:** Creați `AddEditTransactionPage.xaml` și `AddEditTransactionViewModel.cs`. Această pagină va conține câmpuri de input (`Entry`, `DatePicker`) pentru a adăuga o nouă tranzacție.
2.  **Navigare:** Adăugați un buton "Adaugă" pe `TransactionsPage` care navighează la pagina de adăugare.
3.  **Salvare Date:** În `AddEditTransactionViewModel`, la apăsarea butonului "Salvează", apelați metoda corespunzătoare din `TransactionService` pentru a salva noua tranzacție în baza de date.
4.  **Ștergere Tranzacție:** Adăugați o opțiune de ștergere pentru fiecare element din `CollectionView` (ex: un swipe sau un buton).

**Criteriu de succes:** Utilizatorul poate adăuga o tranzacție nouă, ea apare în listă și persistă după ce aplicația este închisă și redeschisă.

---

## Capitolul 3: Adăugiri - Categorii și Dashboard

**Obiectiv:** A crește complexitatea și utilitatea aplicației prin adăugarea de categorii și a unui dashboard vizual.

#### **Task-uri Dev 1 (Core & Data):**
1.  **CRUD pentru Categorii:** Extindeți `DatabaseService` cu metode pentru a gestiona categoriile.
2.  **Logic pentru Dashboard:** Creați un `DashboardService.cs` care oferă metode pentru a calcula:
    - Suma totală a cheltuielilor/veniturilor pe luna curentă.
    - O listă de cheltuieli agregate pe categorie pentru luna curentă.

#### **Task-uri Dev 2 (UI & ViewModel):**
1.  **Management Categorii:** Creați o pagină simplă (`CategoriesPage.xaml`) unde utilizatorul poate vedea și adăuga noi categorii.
2.  **Integrare Categorii:** Modificați pagina de adăugare a tranzacțiilor pentru a include un `Picker` (dropdown) de unde utilizatorul poate selecta o categorie.
3.  **Creare Dashboard:**
    - În `DashboardPage.xaml`, afișați carduri cu informațiile cheie (ex: Total Cheltuit).
    - **(Task Bonus)** Integrați o librărie de grafice (ex: `Microcharts.Maui`) pentru a afișa un grafic (ex: Pie Chart) cu cheltuielile pe categorii.

**Criteriu de succes:** Utilizatorul poate crea categorii, le poate asocia tranzacțiilor, iar Dashboard-ul afișează un rezumat relevant al finanțelor.

---

## Capitolul 4: Extra - Rafinament și Funcții Avansate

**Obiectiv:** A duce aplicația la un nivel superior, adăugând funcționalități care o fac cu adevărat "sofisticată".

#### **Task-uri (pot fi împărțite):**
1.  **Filtrare și Sortare:** În pagina de tranzacții, adăugați butoane sau un meniu pentru a filtra tranzacțiile (ex: după lună, după categorie) și a le sorta (după dată, după sumă).
2.  **Editare Tranzacție:** Implementați funcționalitatea de a edita o tranzacție existentă. Puteți refolosi pagina `AddEditTransactionPage`.
3.  **Stilizare și UI/UX:**
    - Definiți culori și stiluri consistente în `Resources/Styles/Colors.xaml` și `Styles.xaml`.
    - Adăugați iconițe la tab-uri și butoane.
    - Asigurați-vă că aplicația arată bine atât în modul Light, cât și Dark.
4.  **(Funcție Avansată) Bugete Lunare:**
    - Permiteți utilizatorului să seteze un buget maxim pentru o categorie într-o anumită lună.
    - Afișați progresul față de buget în Dashboard sau în pagina de categorii (ex: o bară de progres).

**Criteriu de succes:** Aplicația este stabilă, arată bine și oferă funcționalități avansate care o fac un instrument util și un proiect de portofoliu impresionant.
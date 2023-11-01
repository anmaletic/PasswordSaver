# PasswordSaver

Napraviti program koji će omogućiti sigurnu pohranu zaporki korištenjem nekog standardnog
hash-algoritma. Program treba imati polje u koje se upiše zaporka te tipke "Spremi" i "Provjeri".
Korisnik treba upisati zaporku i pritiskom na tipku "Spremi" program će hashirati upisani tekst
(pretvoriti ga oblik koji se ne može dešifrirati) korištenjem npr. klase
System.Security.Cryptography.SHA512ManagedClass iz .NET biblioteke i spremiti ga u tom
obliku u datoteku. Sljedeći puta kada korisnik upiše zaporku i pritisne tipku "Provjeri", program
treba hashirati upisani tekst, usporediti to sa sadržajem datoteke u koju je prije toga bila
pohranjena zaporka te ispisati obavijest je li zaporka identična izvornoj ili ne.

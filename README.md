# Programmation Web I – TP2

Cours : Programmation Web I  
Cegep de Sainte-Foy  
Session : Hiver 2025  

---

## Partie 1 – Jeu du Hi-Low

### Objectif
Développer un petit jeu interactif en JavaScript où le joueur doit deviner un nombre aléatoire généré par l’ordinateur.  
Le programme indique si le nombre à deviner est plus haut ou plus bas après chaque essai et affiche le nombre total d’essais à la fin.

---

### Fonctionnement
1. L’application génère un nombre aléatoire entre 1 et 100 au démarrage.  
2. Le joueur entre un nombre dans un champ de saisie et clique sur le bouton pour soumettre son essai.  
3. Après chaque tentative :
   - Si le nombre est trop petit : le message indique *plus haut*.  
   - Si le nombre est trop grand : le message indique *plus bas*.  
4. Chaque essai est comptabilisé.  
5. Lorsque le joueur trouve le bon nombre :
   - Un message de victoire s’affiche.  
   - Le compteur d’essais est affiché.  
   - Le joueur peut recommencer une nouvelle partie (nouveau nombre aléatoire et compteur remis à zéro).  

---

### Éléments d’interface
- Un champ de saisie pour le nombre.  
- Un bouton pour soumettre l’essai.  
- Un affichage dynamique des indications (plus haut, plus bas).  
- Un affichage du nombre total d’essais après la victoire.  
- Un bouton pour rejouer.  

---

### Comportement attendu
- Le nombre aléatoire est généré **une seule fois** au début de la partie.  
- Le compteur est incrémenté après chaque essai.  
- L’interface reste claire, fluide et agréable à utiliser.  

---

### Exemple de déroulement
1. Le joueur entre **50** → message : *plus haut*.  
2. Le joueur entre **75** → message : *plus bas*.  
3. Le joueur entre **63** → message : *plus haut*.  
4. Le joueur entre **68** → message : *bravo, vous avez trouvé en 4 essais !*  

---

## Partie 2 – Formulaire du party de Noël

### Objectif
Créer un formulaire Web interactif en JavaScript permettant de recueillir les préférences des employés pour le party de Noël.  
Le formulaire doit s’adapter aux réponses de l’utilisateur en affichant ou masquant dynamiquement certaines sections.

---

### Fonctionnement général
1. Par défaut, seules les questions sur le **nom** et la **présence** sont visibles.  
2. Si l’utilisateur répond **Non** à la question de présence, le formulaire peut être soumis immédiatement.  
3. Si l’utilisateur répond **Oui** :
   - Les choix de **repas**, **accompagnement** et **activités** apparaissent.  
   - Si l’utilisateur indique qu’il sera accompagné, de nouveaux champs s’affichent pour saisir le nom et le repas de l’accompagnateur.  
4. L’utilisateur doit sélectionner **exactement deux activités** parmi la liste proposée.  
5. Tous les champs visibles doivent être remplis avant la soumission.  
6. Les erreurs sont affichées sous forme de messages clairs et disparaissent après correction.  
7. Le formulaire est envoyé en **POST** à l’adresse fournie :  
   `https://progweb1-validation-formulaire-e4hae7gedrdvbbaq.canadacentral-01.azurewebsites.net/`

---

### Champs du formulaire
| Nom du champ | Type | Détails |
|---------------|------|----------|
| nomEmploye | texte | Nom de l’employé (obligatoire) |
| presenceEmploye | radio | oui / non |
| choixRepasEmploye | radio | pouletAnanas, boeufBraise, tourtiere |
| seraAccompagne | radio | oui / non |
| nomInvite | texte | Nom de l’accompagnateur (si applicable) |
| choixRepasInvite | radio | pouletAnanas, boeufBraise, tourtiere |
| Activités | checkbox | traineau, noelDisco, karaoke, glissades, laserTag, casino (exactement deux à cocher) |

---

### Règles de validation
- Tous les champs visibles doivent être remplis.  
- Si plus ou moins de deux activités sont sélectionnées, un message d’erreur s’affiche.  
- Les erreurs bloquent la soumission tant qu’elles ne sont pas corrigées.  
- Les messages disparaissent une fois les champs corrigés.  
- Tous les labels doivent être associés correctement à leurs champs pour assurer l’accessibilité.

---

### Interface
- Interface claire, simple et responsive.  
- Sections qui apparaissent ou disparaissent dynamiquement selon les choix de l’utilisateur.  
- Messages d’erreur bien visibles et informatifs.  
- Le tout entièrement en français.  

---

## Contraintes techniques
- Un seul fichier HTML et un seul fichier JavaScript par partie.  
- Travail individuel.  
- Aucune utilisation d’intelligence artificielle.  
- Code lisible, indenté et bien commenté.  
- Textes et messages d’erreur rédigés en français.  

---

## Auteur
Cherif Ouattara  
Etudiant AEC Programmation, bases de donnees et serveurs  
Cegep de Sainte-Foy  

GitHub : [github.com/BoOm00001](https://github.com/BoOm00001)  
LinkedIn : [linkedin.com/in/cherif-ouattara](https://www.linkedin.com/in/cherif-ouattara/)

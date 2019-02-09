using System.Collections.Generic;
namespace timetable
{
    public class PersistenceDump {
        public static List<Lecturer> AddLecturer() 
        {
            List<Lecturer> lecturers = new List<Lecturer>();
            lecturers.Add(new Lecturer("Maik", "Pfeffer"));
            lecturers.Add(new Lecturer("Marko", "Kaufmann"));
            lecturers.Add(new Lecturer("Eric", "Schroeder"));
            lecturers.Add(new Lecturer("Uwe", "Freud"));
            lecturers.Add(new Lecturer("Felix", "Cole"));
            lecturers.Add(new Lecturer("Markus", "Mehler"));
            lecturers.Add(new Lecturer("Antje", "Papst"));
            lecturers.Add(new Lecturer("Kevin", "Bohm"));
            lecturers.Add(new Lecturer("Stephan", "Pfeiffer"));
            lecturers.Add(new Lecturer("Dirk", "Sankt"));
            lecturers.Add(new Lecturer("Florian", "Muench"));
            lecturers.Add(new Lecturer("Melania", "Dolgorukova"));
            lecturers.Add(new Lecturer("Thorsten", "Kaiser"));
            lecturers.Add(new Lecturer("Markus", "Richter"));
            lecturers.Add(new Lecturer("Mario", "Hoffmann"));
            lecturers.Add(new Lecturer("Niklas", "Jung"));
            lecturers.Add(new Lecturer("Martin", "Herrmann"));
            lecturers.Add(new Lecturer("Matthias", "Lange"));
            lecturers.Add(new Lecturer("Erik", "Seiler"));
            lecturers.Add(new Lecturer("Sebastian", "Gaertner"));
            lecturers.Add(new Lecturer("Klaus", "Schuster"));
            lecturers.Add(new Lecturer("Thorsten", "Schulze"));
            lecturers.Add(new Lecturer("Erik", "Osterhagen"));
            lecturers.Add(new Lecturer("Frank", "Junker"));
            lecturers.Add(new Lecturer("Ralf", "Bieber"));
            lecturers.Add(new Lecturer("Max", "Engenhart"));
            JsonPersistence.SerializeLecturer(lecturers);
            return lecturers;
        }

        public static void AddCourses()
        {
            List<Lecturer> lecturers = AddLecturer();
            List<Semester> semesters = JsonPersistence.DeserializeSemesters();
            List<Course> courses = new List<Course>();
            List<Equipment> standard = new List<Equipment>();
            standard.Add(Equipment.beamer);
            standard.Add(Equipment.whiteboard);
            standard.Add(Equipment.electricalVenetians);
            standard.Add(Equipment.blackboard);

            List<Equipment> studio = new List<Equipment>();
            studio.Add(Equipment.studio);

            List<Equipment> computer = new List<Equipment>();
            computer.Add(Equipment.beamer);
            computer.Add(Equipment.whiteboard);
            computer.Add(Equipment.electricalVenetians);
            computer.Add(Equipment.blackboard);
            computer.Add(Equipment.computer);

            List<Equipment> vfx = new List<Equipment>();
            vfx.Add(Equipment.vfx);

            // FIRST SEMESTER
            Course aBwl = new Course(semesters[0], lecturers[20], "Allgemeine Betriebswirtschaftslehre");
            Course grdlUntGr = new Course(semesters[0], lecturers[20], "Grundlagen Unternehmensgründung");
            aBwl.Requirements = standard;
            grdlUntGr.Requirements = standard;
            aBwl.SetSemester(semesters[1]);
            aBwl.SetSemester(semesters[2]);
            grdlUntGr.SetSemester(semesters[1]);
            grdlUntGr.SetSemester(semesters[2]);
            courses.Add(aBwl);
            courses.Add(grdlUntGr);

            Course programmieren = new Course(semesters[0], lecturers[4], "Programmieren");
            Course progOmb = new Course(semesters[2], lecturers[18], "Programmieren");
            Course eiA  = new Course(semesters[1], lecturers[21], "Entwicklung Interaktiver Anwendungen");
            Course eiAP  = new Course(semesters[1], lecturers[21], "Entwicklung Interaktiver Anwendungen Praktikum");
            Course progPrak = new Course(semesters[0], lecturers[4], "Programmieren Praktikum");
            Course progPrakOmb = new Course(semesters[2], lecturers[18], "Programmieren Praktikum");
            programmieren.Requirements = standard;
            progOmb.Requirements = standard;
            eiA.Requirements = standard;
            eiAP.Requirements = computer;
            progPrak.Requirements = computer;
            progPrakOmb.Requirements = computer;
            courses.Add(programmieren);
            courses.Add(progPrak);
            courses.Add(progOmb);
            courses.Add(progPrakOmb);
            courses.Add(eiA);
            courses.Add(eiAP);

            Course audioTech = new Course(semesters[0], lecturers[14], "Audiotechnik");
            audioTech.SetSemester(semesters[2]);
            Course videoTechMib = new Course(semesters[0], lecturers[14], "Videotechnik");
            Course videoTechOmb = new Course(semesters[2], lecturers[15], "Videotechnik");
            videoTechOmb.SetSemester(semesters[2]);
            Course medienTechMib = new Course(semesters[0], lecturers[14], "Medientechnik Praktikum");            
            Course medienTechOmb = new Course(semesters[2], lecturers[19], "Medientechnik Praktikum");
            Course medienTechMkb = new Course(semesters[1], lecturers[19], "Medientechnik Praktikum");
            audioTech.Requirements = standard;
            videoTechMib.Requirements = standard;
            videoTechOmb.Requirements = standard;
            medienTechMib.Requirements = studio;
            medienTechOmb.Requirements = studio;
            medienTechMkb.Requirements = studio;
            courses.Add(audioTech);
            courses.Add(videoTechMib);
            courses.Add(medienTechMib);
            courses.Add(videoTechOmb);
            courses.Add(medienTechOmb);
            courses.Add(medienTechMkb);


            Course mathe1mib = new Course(semesters[0], lecturers[15], "Mathematik in Medien und Informatik");
            Course mathe1mibPrak = new Course(semesters[0], lecturers[15], "Mathematik in Medien und Informatik Praktikum");
            Course phys1mib = new Course(semesters[0], lecturers[15], "Physik in Medien und Informatik");
            mathe1mib.SetSemester(semesters[2]);
            mathe1mibPrak.SetSemester(semesters[2]);
            phys1mib.SetSemester(semesters[2]);
            mathe1mib.Requirements = standard;
            mathe1mibPrak.Requirements = standard;
            phys1mib.Requirements = standard;

            courses.Add(mathe1mib);
            courses.Add(mathe1mibPrak);
            courses.Add(phys1mib);


            Course grundlagenMedienG = new Course(semesters[0], lecturers[5], "Grundlagen Mediengestaltung");
            Course grundlagenMedienGP = new Course(semesters[0], lecturers[5], "Grundlagen Mediengestaltung Praktikum");
            Course medPsych = new Course(semesters[0], lecturers[3], "Medienpsychologie");
            Course MedAn = new Course(semesters[1], lecturers[5], "Medienanalyse");
            Course grdlMedKonzSem = new Course(semesters[1], lecturers[6], "Grundlagen Medienkonzeption Seminar");
            grundlagenMedienG.Requirements = standard;
            grundlagenMedienGP.Requirements = standard;
            medPsych.Requirements = standard;
            MedAn.Requirements = standard;
            grdlMedKonzSem.Requirements = standard;

            grundlagenMedienG.SetSemester(semesters[1]);
            grundlagenMedienG.SetSemester(semesters[2]);
            grundlagenMedienGP.SetSemester(semesters[1]);
            grundlagenMedienGP.SetSemester(semesters[2]);
            medPsych.SetSemester(semesters[1]);
            medPsych.SetSemester(semesters[2]);
            courses.Add(grundlagenMedienGP);
            courses.Add(grundlagenMedienG);
            courses.Add(medPsych);
            courses.Add(MedAn);
            courses.Add(grdlMedKonzSem);

            // SECOND SEMESTER

            Course mathe2mkb = new Course(semesters[4], lecturers[15], "Mathematische Grundlagen von Gestaltung und Computergrafik");
            Course cg = new Course(semesters[3], lecturers[12], "Computergrafik und 3D Modellierung");
            Course cgPrak = new Course(semesters[3], lecturers[12], "Computergrafik und 3D Modellierung Praktikum");
            cg.SetSemester(semesters[4]); 
            cg.SetSemester(semesters[5]); 
            cg.Requirements = standard;
            mathe2mkb.Requirements = standard;
            cgPrak.Requirements = computer;
            courses.Add(cg);
            courses.Add(cgPrak);
            courses.Add(mathe2mkb);

            Course avProdPrak = new Course(semesters[4], lecturers[14], "AV-Produktion Praktikum");
            avProdPrak.SetSemester(semesters[5]);
            avProdPrak.Requirements = vfx;
            Course avProd = new Course(semesters[4], lecturers[14], "AV-Produktion");
            avProd.SetSemester(semesters[5]);
            courses.Add(avProd);
            courses.Add(avProdPrak);
            avProdPrak.Requirements = vfx;
            avProd.Requirements = standard;

            Course eiA2 = new Course(semesters[4], lecturers[2], "Entwicklung Interaktiver Anwendungen II");
            Course eiA2Prak = new Course(semesters[4], lecturers[2], "Entwicklung Interaktiver Anwendungen II Praktikum");
            courses.Add(eiA2);
            courses.Add(eiA2Prak);
            eiA2.Requirements = standard;
            eiA2Prak.Requirements = computer;

            Course UsExD = new Course(semesters[3], lecturers[10], "User Experience Design");
            Course UsExDPrak = new Course(semesters[3], lecturers[10], "User Experience Design Praktikum");
            UsExD.Requirements = standard;
            UsExDPrak.Requirements = standard;
            UsExD.SetSemester(semesters[4]); 
            UsExD.SetSemester(semesters[5]); 
            UsExDPrak.SetSemester(semesters[4]); 
            UsExDPrak.SetSemester(semesters[5]); 
            courses.Add(UsExD);
            courses.Add(UsExDPrak);

            Course marketing = new Course(semesters[3], lecturers[10], "Marketing");
            Course medienOeko = new Course(semesters[3], lecturers[10], "Medienökonomie");
            marketing.SetSemester(semesters[4]); 
            marketing.SetSemester(semesters[5]); 
            medienOeko.SetSemester(semesters[4]); 
            medienOeko.SetSemester(semesters[5]); 
            marketing.Requirements = standard;
            medienOeko.Requirements = standard;

            courses.Add(marketing);
            courses.Add(medienOeko);

            Course mathe2mibSem = new Course(semesters[3], lecturers[15], "Mathematik und Simulation Seminar");
            Course mathe2mib = new Course(semesters[3], lecturers[11], "Mathematik und Simulation");
            Course mathe2mibPrak = new Course(semesters[3], lecturers[11], "Mathematik und Simulation Praktikum");
            mathe2mibSem.Requirements = standard;
            mathe2mib.Requirements = standard;
            mathe2mibPrak.Requirements = standard;

            courses.Add(mathe2mibSem);
            courses.Add(mathe2mib);
            courses.Add(mathe2mibPrak);

            Course gisMib = new Course(semesters[3], lecturers[23], "Grundlagen Interaktiver Systeme");
            Course gis2MibPrak = new Course(semesters[3], lecturers[23], "Grundlagen Interaktiver Systeme Praktikum");
            gisMib.Requirements = standard;
            gis2MibPrak.Requirements = computer;
            courses.Add(gisMib);
            courses.Add(gis2MibPrak);

            Course gisOmbPrak = new Course(semesters[5], lecturers[18], "Grundlagen Interaktiver Systeme");
            Course gis2OmbbPrak = new Course(semesters[5], lecturers[18], "Grundlagen Interaktiver Systeme Praktikum");
            gisOmbPrak.Requirements = standard;
            gis2OmbbPrak.Requirements = computer;
            courses.Add(gisOmbPrak);
            courses.Add(gis2OmbbPrak);

            Course mathe2omb = new Course(semesters[5], lecturers[11], "Geometrische und statische Modellierung");
            Course mathe2ombPrak = new Course(semesters[5], lecturers[11], "Geometrische und statische Modellierung Praktikum");
            mathe2omb.Requirements = standard;
            mathe2ombPrak.Requirements = standard;
            courses.Add(mathe2omb);
            courses.Add(mathe2ombPrak);

            // FOURTH SEMESTER

            Course project = new Course(semesters[9], lecturers[13], "Projektmanagement und Softskills");
            project.Requirements = standard;
            project.SetSemester(semesters[10]);
            project.SetSemester(semesters[11]);
            courses.Add(project);

            Course gdv = new Course(semesters[9], lecturers[19], "Graphische Datenverarbeitung");
            Course gdvPrak = new Course(semesters[9], lecturers[19], "Graphische Datenverarbeitung Praktikum");
            Course komSys = new Course(semesters[9], lecturers[1], "Kommunikationssysteme");
            Course komSysPrak = new Course(semesters[9], lecturers[1], "Kommunikationssysteme Praktikum");
            Course softwaredesign = new Course(semesters[9], lecturers[2], "Softwaredesign");
            Course softwaredesignPrak = new Course(semesters[9], lecturers[2], "Softwaredesign Praktikum");
            gdv.Requirements = standard;
            gdvPrak.Requirements = computer;
            komSys.Requirements = standard;
            komSysPrak.Requirements = standard;
            softwaredesign.Requirements = computer;
            softwaredesignPrak.Requirements = computer;
            courses.Add(gdv);
            courses.Add(gdvPrak);
            courses.Add(komSys);
            courses.Add(komSysPrak);
            courses.Add(softwaredesign);
            courses.Add(softwaredesignPrak);

            Course ebusi = new Course(semesters[11], lecturers[13], "E-Business");
            Course medMomWi = new Course(semesters[11], lecturers[22], "Medien- und Kommunikationswirtschaft");
            Course webtech = new Course(semesters[11], lecturers[1], "Webtechnologie");
            Course webtechPrak = new Course(semesters[11], lecturers[1], "Webtechnologie Praktikum");
            Course resWebDes = new Course(semesters[11], lecturers[10], "Responsive Web Design");
            Course resWebDesPrak = new Course(semesters[11], lecturers[10], "Responsive Web Design Praktikum");
            ebusi.Requirements = standard;
            medMomWi.Requirements = standard;
            webtech.Requirements = standard;
            webtechPrak.Requirements = standard;
            resWebDes.Requirements = standard;
            resWebDesPrak.Requirements = computer;
            courses.Add(ebusi);
            courses.Add(medMomWi);
            courses.Add(webtech);
            courses.Add(webtechPrak);
            courses.Add(resWebDes);
            courses.Add(resWebDesPrak);

            Course konz = new Course(semesters[10], lecturers[6], "Konzeption");
            Course ideenEnt = new Course(semesters[10], lecturers[5], "Ideenentwicklung");
            Course eLearn = new Course(semesters[10], lecturers[3], "E-Learning und Online-Learning");
            Course eLearnPrak = new Course(semesters[10], lecturers[3], "E-Learning und Online-Learning Praktikum");
            Course storyTell = new Course(semesters[10], lecturers[24], "Storytelling");
            Course creaWrit = new Course(semesters[10], lecturers[24], "Creative Writing");
            konz.Requirements = standard;
            ideenEnt.Requirements = standard;
            eLearn.Requirements = standard;
            eLearnPrak.Requirements = standard;
            storyTell.Requirements = standard;
            creaWrit.Requirements = standard;
            courses.Add(konz);
            courses.Add(ideenEnt);
            courses.Add(eLearn);
            courses.Add(eLearnPrak);
            courses.Add(storyTell);
            courses.Add(creaWrit);

            Course datMed = new Course(semesters[12], lecturers[12], "Datenverarbeitung in der Medienproduktion");
            Course vertAn = new Course(semesters[12], lecturers[4], "Verteilte Anwendungen");
            Course vertAnPrak = new Course(semesters[12], lecturers[4], "Verteile Anwendungen Praktikum");
            Course digAv = new Course(semesters[12], lecturers[8], "Digitale AV-Technik");
            datMed.Requirements = standard;
            vertAn.Requirements = standard;
            vertAnPrak.Requirements = standard;
            digAv.Requirements = standard;

            courses.Add(datMed);
            courses.Add(vertAn);
            courses.Add(vertAnPrak);
            courses.Add(digAv);

            Course intDes = new Course(semesters[14], lecturers[25], "Interface Design");
            Course intDesPrak = new Course(semesters[14], lecturers[25], "Interface Design Praktikum");
            Course streamAn = new Course(semesters[14], lecturers[8], "Streaming Anwendungen");
            Course streamAnPrak = new Course(semesters[14], lecturers[8], "Streaming Anwendungen Praktikum");
            intDes.Requirements = standard;
            intDesPrak.Requirements = computer;
            streamAn.Requirements = standard;
            streamAnPrak.Requirements = computer;

            courses.Add(intDes);
            courses.Add(intDesPrak);
            courses.Add(streamAn);
            courses.Add(streamAnPrak);

            Course intDesMkb = new Course(semesters[13], lecturers[10], "Interface Design");
            Course intDesMkbPrak = new Course(semesters[13], lecturers[10], "Interface Design Praktikum");
            Course opMark = new Course(semesters[13], lecturers[13], "Operatives Marketing");
            intDesMkb.Requirements = standard;
            intDesMkbPrak.Requirements = computer;
            opMark.Requirements = standard;
            courses.Add(intDesMkb);
            courses.Add(intDesMkbPrak);
            courses.Add(opMark);

            List<OptionalCourse> optionalCourses = new List<OptionalCourse>();

            OptionalCourse spieleentwicklung = new OptionalCourse(lecturers[2], "Spieleentwicklung", 12);
            spieleentwicklung.Requirements = computer;
            optionalCourses.Add(spieleentwicklung);

            OptionalCourse deepLearningI = new OptionalCourse(lecturers[11], "Introduction to Deep Learning", 8);
            deepLearningI.Requirements = standard;
            optionalCourses.Add(deepLearningI);

            OptionalCourse deepLearningIPrak = new OptionalCourse(lecturers[11], "Introduction to Deep Learning", 17);
            deepLearningIPrak.Requirements = computer;
            optionalCourses.Add(deepLearningIPrak);

            OptionalCourse deepLearningII = new OptionalCourse(lecturers[11], "Introduction to Deep Learning II", 20);
            deepLearningII.Requirements = standard;
            optionalCourses.Add(deepLearningII);

            OptionalCourse liveMixSoundDes = new OptionalCourse(lecturers[14], "Livemix und Sounddesign", 22);
            liveMixSoundDes.Requirements = vfx;
            optionalCourses.Add(liveMixSoundDes);

            OptionalCourse photographie = new OptionalCourse(lecturers[5], "Photographie", 8);
            photographie.Requirements = standard;
            optionalCourses.Add(photographie);

            OptionalCourse vFXCompositing  = new OptionalCourse(lecturers[8], "VFX und Compositing", 18);
            vFXCompositing.Requirements = standard;
            optionalCourses.Add(vFXCompositing);

            OptionalCourse medGegenkultur = new OptionalCourse(lecturers[22], "Mediale Gegenkultur", 23);
            medGegenkultur.Requirements = standard;
            optionalCourses.Add(medGegenkultur);

            JsonPersistence.SerializeOptionalCourses(optionalCourses);
            JsonPersistence.SerializeCourses(courses);
        }

        public static void AddSemester() 
        {
            List<Semester> semesters = new List<Semester>();
            int size = 40;
            int id = 0;
            for (int i = 1; i < 8; i++)
            {
                id += 1;
                semesters.Add(new Semester("MIB", i, size, id));
                id += 1;
                semesters.Add(new Semester("MKB", i, size, id));
                id += 1;
                semesters.Add(new Semester("OMB", i, size, id));
                size -= size/8;
            }
            JsonPersistence.SerializeSemesters(semesters);
        }

        public static void AddRooms()
        {
            List<Room> rooms = new List<Room>();
            List<Equipment> standard = new List<Equipment>();
            standard.Add(Equipment.beamer);
            standard.Add(Equipment.whiteboard);
            standard.Add(Equipment.electricalVenetians);
            standard.Add(Equipment.blackboard);

            List<Equipment> studio = new List<Equipment>();
            studio.Add(Equipment.studio);

            List<Equipment> computer = new List<Equipment>();
            computer.Add(Equipment.beamer);
            computer.Add(Equipment.whiteboard);
            computer.Add(Equipment.electricalVenetians);
            computer.Add(Equipment.blackboard);
            computer.Add(Equipment.computer);

            List<Equipment> vfx = new List<Equipment>();
            vfx.Add(Equipment.vfx);

            rooms.Add(new Room("i0.08", vfx, 80));
            rooms.Add(new Room("i0.13", standard, 60));
            rooms.Add(new Room("i0.14", standard, 60));
            rooms.Add(new Room("i0.15", standard, 80));
            rooms.Add(new Room("i0.16", standard, 120));
            rooms.Add(new Room("i0.17", standard, 120));
            rooms.Add(new Room("i1.17", computer, 40));
            rooms.Add(new Room("i1.18", vfx, 80));
            rooms.Add(new Room("i1.19", computer, 40));
            rooms.Add(new Room("l1.05", standard, 40));
            rooms.Add(new Room("l1.06", standard, 60));
            rooms.Add(new Room("l2.05", standard, 40));
            rooms.Add(new Room("l2.07", computer, 40));
            rooms.Add(new Room("l2.08", computer, 25));
            rooms.Add(new Room("studio", studio, 40));
            rooms.Add(new Room("c0.01", computer, 40));

            JsonPersistence.SerializeRooms(rooms);
        }

        public static void AddPeriods()
        {
            Period[] periods  = new Period[25];
            for (int i = 0; i < periods.Length; i++)
            {
                periods[i] = new Period();
            }
            JsonPersistence.SerializePeriods(periods);
        }
    }
}
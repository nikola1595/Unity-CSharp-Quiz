-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 27, 2019 at 12:27 AM
-- Server version: 10.1.39-MariaDB
-- PHP Version: 7.3.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `unitybaza`
--

-- --------------------------------------------------------

--
-- Table structure for table `questions`
--

CREATE TABLE `questions` (
  `id` int(11) NOT NULL,
  `text` varchar(128) NOT NULL,
  `answer` varchar(256) NOT NULL,
  `a1` varchar(256) NOT NULL,
  `a2` varchar(256) NOT NULL,
  `a3` varchar(256) NOT NULL,
  `a4` varchar(256) NOT NULL,
  `size` int(11) NOT NULL,
  `timer` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `questions`
--

INSERT INTO `questions` (`id`, `text`, `answer`, `a1`, `a2`, `a3`, `a4`, `size`, `timer`) VALUES
(4, 'Can \"this\" be used within a static method?', 'No', 'Yes', 'No', '', '', 2, 10),
(5, 'Which of the following is correct about dynamic Type in C#?', 'Both of the above.', 'You can store any type of value in the dynamic data type variable.', 'Type checking for these types of variables takes place at run-time.', 'Both of the above.', 'None of the above.', 4, 20),
(6, 'Which of the following converts a type (integer or string type) to date-time structures in C#?', 'ToDateTime', 'ToString', 'ToSingle', 'ToChar', 'ToDateTime', 4, 15),
(7, 'Which of the following operator casts without raising an exception if the cast fails in C#?', 'as', '?:', 'is', 'as', '*', 4, 10),
(8, 'Which of the following statements is correct about access specifiers in C#?', 'Both of the above', 'Encapsulation is implemented by using access specifiers.', 'An access specifier defines the scope and visibility of a class member.', 'Both of the above', 'None of the above.', 4, 20),
(9, 'Which of the following is the correct about interfaces in C#?', 'Both of the above.', 'Interfaces are declared using the interface keyword.', 'Interface methods are public by default.', 'Both of the above.', 'None of the above.', 4, 20),
(10, 'You can define one namespace inside another namespace.', 'true', 'true', 'false', '', '', 2, 10),
(11, 'Which of the following is true about catch block in C#?', 'Both of the above.', 'A program catches an exception with an exception handler at the place in a program where you want to handle the problem.', 'The catch keyword indicates the catching of an exception.', 'Both of the above.', 'None of the above', 4, 20),
(12, 'Which of the followings is not allowed in C# as access modifier?', 'friend', 'public', 'friend', 'internal', 'protected', 4, 10),
(13, 'Which of the following C# keywords has nothing to do with multithreading?', 'sealed', 'async', 'await', 'sealed', 'lock', 4, 10),
(14, 'Find an invalid expression among the following C# Generics examples.', 'class A where T : class, struct', 'class A where T : class, new()', 'class A where T : struct, IComparable', 'class A where T : class, struct', 'class A where T : Stream where U : IDisposable', 4, 30),
(15, 'new keyword in C# is used to creat new object from the type. Which of the followings is not allowed to use new keyword?', 'Interface : var a = new IComparable();', 'Class: var a = new Class1();', 'Interface : var a = new IComparable();', 'Struct : var a = new Struct1();', 'C# object : var a = new object();', 4, 20),
(16, 'Find a correct statement about C# exception', 'C# exception occrs at run time', 'C# exception occrs at compile time', 'C# exception occrs at linking time', 'C# exception occrs at JIT compile time', 'C# exception occrs at run time', 4, 20),
(17, 'Find an invalid Main() method prototype, which is entry point in C#?', 'public static long Main(string[] args)', 'public static void Main()', 'public static int Main()', 'public static void Main(string[] s)', 'public static long Main(string[] args)', 4, 20),
(18, 'C# / .NET supports various built-in data structures. Which of the following data structures does not exist as built-in?', 'Binary Tree', 'Array', 'D-Array', 'Binary Tree', 'Linked List', 4, 15),
(19, 'In C#, what is similar to C++ function pointer?', 'Delegate', 'Event', 'Interface', 'Delegate', 'Method', 4, 10),
(20, 'Which of the following C# methods is not valid? (method body elided)', 'private var GetData() {}', 'public void Set(dynamic o) {}', 'public dynamic Get() {}', 'private var GetData() {}', 'protected override int[] A() {}', 4, 15),
(21, 'Which of the following statements is not valid to create new object in C#?', 'var a = new IComparable();', 'var a = new Int32();', 'var a = new String();', 'var a = new IComparable();', 'var a = new [] {0};', 4, 20),
(22, 'Which of the following operators cannot use operator overloading?', 'operator ||', 'operator ++', 'operator &', 'operator ||', 'operator true', 4, 10),
(23, 'Which of the following statements is incorrect about C# delegate?', 'C# delegate can not use +=, -= operators', 'C# delegate supports multicast', 'C# delegate is considered as a technical basis of C# event', 'C# delegate can be used when passing a reference to a method', 'C# delegate can not use +=, -= operators', 4, 30),
(24, 'Which of the following statements is true about C# anonymous type?', 'Anonymous type is an immutable type', 'Anonymous type is an immutable type', 'Anonymous type can add new property once it is created', 'Anonymous type can add an event', 'You can use a delegate for a method in anonymous type', 4, 30),
(25, 'In multithread programming, which of the followings is not using Thread Pool?', 'Thread class', 'BackgroundWorker class', 'Asynchronous delegate', 'Thread class', 'Task class', 4, 20),
(26, 'Which Of The Following Can Be Used To Define The Member Of A Class Externally?', '::', ':', '::', '#', '', 3, 10),
(27, 'Which Of The Following Operator Can Be Used To Access The Member Function Of A Class?', '.', ':', '::', '.', '#', 4, 10),
(28, 'The space required for structure variables is allocated on stack.', 'True', 'True', 'False', '', '', 2, 10),
(29, 'Creating empty structures is allowed in C#.NET.', 'False', 'True', 'False', '', '', 2, 10),
(30, 'Which of the following statements is correct?', 'Object Oriented Programming paradigm gives equal importance to data and the procedures that work on the data.', 'Procedural Programming paradigm is different than structured programming paradigm.', 'Object Oriented Programming paradigm stresses on dividing the logic into smaller parts and writing procedures for each part.', 'Classes and objects are corner stones of structured programming paradigm.', 'Object Oriented Programming paradigm gives equal importance to data and the procedures that work on the data.', 4, 40),
(31, 'Which one of the following statements is correct?', 'The default value of numeric array elements is zero.', 'The default value of numeric array elements is zero.', 'The length of an Array is the number of dimensions in the Array.', 'The rank of an Array is the total number of elements it can contain.', 'Array elements can be of integer type only.', 4, 30),
(32, 'Which of the following statements is correct?', 'A constructor can be used to set default values and limit instantiation.', 'A constructor can be used to set default values and limit instantiation.', 'C# provides a copy constructor.', 'Destructors are used with classes as well as structures.', 'A class can have more than one destructor.', 4, 20),
(33, 'Which of the following statements is correct about constructors?', 'If we do not provide a constructor, then the compiler provides a zero-argument constructor.', 'If we provide a one-argument constructor then the compiler still provides a zero-argument constructor.', 'Static constructors can use optional arguments.', 'Overloaded constructors cannot use optional arguments.', 'If we do not provide a constructor, then the compiler provides a zero-argument constructor.', 4, 30),
(34, 'How many values is a function capable of returning?', '1', '1', '0', 'Depends upon how many params arguments does it use.', 'Any number of values.', 4, 10),
(35, 'Which of the following statements is correct about an interface used in C#.NET?', 'Properties can be declared inside an interface.', 'One class can implement only one interface.', 'In a program if one class implements an interface then no other class in the same program can implement this interface.', 'From two base interfaces a new interface cannot be inherited.', 'Properties can be declared inside an interface.', 4, 30),
(36, 'Which of the following statements is correct about a namespace in C#.NET?', 'Namespaces help us to control the visibility of the elements present in it.', 'Namespaces help us to control the visibility of the elements present in it.', 'A namespace can contain a class but not another namespace.', 'If not mentioned, then the name \'root\' gets assigned to the namespace.', 'It is necessary to use the using statement to be able to use an element of a namespace.', 4, 30),
(37, 'A derived class can stop virtual inheritance by declaring an override as', 'sealed', 'inherits', 'extends', 'sealed', 'inheritable', 4, 10),
(38, 'Which of the following statements is correct?', 'When used as a modifier, the new keyword explicitly hides a member inherited from a base class.', 'When used as a modifier, the new keyword explicitly hides a member inherited from a base class.', 'Operator overloading works in different ways for structures and classes.', 'It is not necessary that all operator overloads are static methods of the class.', 'The cast operator can be overloaded.', 4, 20),
(39, 'Which of the following statements is correct?', 'When overriding a method, the names and type signatures of the override method must be the same as the virtual method that is being overriden.', 'Static methods can be a virtual method.', 'Abstract methods can be a virtual method.', 'It is necessary to override a virtual method.', 'When overriding a method, the names and type signatures of the override method must be the same as the virtual method that is being overriden.', 4, 30),
(40, '	\r\nWhich of the following statements is correct?', 'The conditional logical operators cannot be overloaded.', 'The conditional logical operators cannot be overloaded.', 'When a binary operator is overloaded the corresponding assignment operator, if any, must be explicitly overloaded.', 'We can use the default equality operator in an overloaded implementation of the equality operator.', 'A public or nested public reference type does not overload the equality operator.', 4, 30),
(41, 'A property can be declared inside a class, struct, Interface.', 'True', 'True', 'False', '', '', 2, 10),
(42, 'Which of the following statements is correct about properties used in C#.NET?', 'A property can be either read only or write only.', 'A property can simultaneously be read only or write only.', 'A property can be either read only or write only.', 'A write only property will have only get accessor.', 'A write only property will always return a value.', 4, 10),
(43, 'Which of the following statement is correct about a String in C#.NET?', 'A String has a zero-based index.', 'A String is mutable because it can be modified once it has been created.', 'Methods of the String class can be used to modify the string.', 'A number CANNOT be represented in the form of a String.', 'A String has a zero-based index.', 4, 20),
(44, 'Which of the following is NOT a .NET Exception class?', 'StackMemoryException', 'Exception', 'StackMemoryException', 'DivideByZeroException', 'OutOfMemoryException', 4, 20),
(45, 'In C#.NET if we do not catch the exception thrown at runtime then which of the following will catch it?', 'CLR', 'Compiler', 'CLR', 'Linker', 'Loader', 4, 10),
(46, 'Which of the following is an 8-byte Integer?', 'Long', 'Char', 'Long', 'Short', 'Byte', 4, 10),
(47, 'Which of the following is NOT an Integer?', 'Char', 'Char', 'Byte', 'Short', 'Long', 4, 10),
(48, 'What is the size of a Decimal?', '32 byte', '4 byte', '8 byte', '16 byte', '32 byte', 4, 10),
(49, 'Which of the following is the correct default value of a Boolean type?', 'False', '0', '1', 'True', 'False', 4, 10),
(50, 'Which of the following should be used to implement a \'Like a\' or a \'Kind of\' relationship between two entities?', 'Inheritance', 'Polymorphism', 'Containership', 'Inheritance', 'Encapsulation', 4, 20),
(51, 'How can you prevent inheritance from a class in C#.NET ?', 'Declare the class as sealed.', 'Declare the class as shadows.', 'Declare the class as overloads.', 'Declare the class as sealed.', 'Declare the class as suppress', 4, 20),
(52, 'Which of the following .NET components can be used to remove unused references from the managed heap?', 'Garbage Collector', 'Common Language Infrastructure', 'CLR', 'Garbage Collector', 'Class Loader', 4, 20),
(53, 'Which of the following statements is correct about classes and objects in C#.NET?', 'Objects are always nameless.', 'Class is a value type.', 'Objects are always nameless.', 'Objects of smaller size are created on the heap', 'Since objects are typically big in size, they are created on the stack.', 4, 20),
(54, 'Is it possible to invoke Garbage Collector explicitly?', 'Yes', 'Yes', 'No', '', '', 2, 10);

-- --------------------------------------------------------

--
-- Table structure for table `scores`
--

CREATE TABLE `scores` (
  `id` int(11) NOT NULL,
  `userid` int(11) NOT NULL,
  `score` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `scores`
--

INSERT INTO `scores` (`id`, `userid`, `score`) VALUES
(1, 1, 25),
(2, 1, 40),
(3, 1, 1),
(4, 2, 50),
(5, 3, 21),
(6, 0, 0),
(7, 0, 0),
(9, 0, 20),
(10, 2, 100),
(11, 2, 44),
(12, 0, 80),
(13, 0, 80),
(14, 0, 80),
(15, 0, 80),
(16, 0, 80),
(17, 0, 80),
(18, 0, 80),
(19, 0, 80),
(20, 0, 80),
(21, 0, 80),
(22, 0, 80),
(23, 0, 20);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `email`) VALUES
(2, 'uros', '123', 'u@u.com'),
(3, 'mils', '123', 'u@m.com'),
(4, 'zils', '123', 'u@z.com'),
(5, 'nemanja', 'qwert12345', 'nemanja@gmail.com'),
(6, 'Lazar', 'qwerty', 'lazar@gmail.com'),
(7, 'Nikola', 'qwerty', 'nikola@gmail.com'),
(8, '', '', '');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `scores`
--
ALTER TABLE `scores`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `questions`
--
ALTER TABLE `questions`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=55;

--
-- AUTO_INCREMENT for table `scores`
--
ALTER TABLE `scores`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

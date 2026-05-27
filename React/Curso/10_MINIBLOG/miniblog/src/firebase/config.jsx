import { initializeApp } from "firebase/app";
import { getFirestore } from "firebase/firebase";

const firebaseConfig = {
  apiKey: "AIzaSyAE1M5glfVDZIrNd3OZOhJFqvkbC7Sb2xc",
  authDomain: "miniblog-29f8b.firebaseapp.com",
  projectId: "miniblog-29f8b",
  storageBucket: "miniblog-29f8b.firebasestorage.app",
  messagingSenderId: "1056791006964",
  appId: "1:1056791006964:web:42d4d0ac882abb193318a1"
};

const app = initializeApp(firebaseConfig);

const db = getFirestore(app);

export {db};
import { initializeApp } from 'firebase/app'
import { getFirestore, doc, getDoc, setDoc } from 'firebase/firestore'
const firebaseConfig = {
  apiKey: 'AIzaSyCGGKGkCprzAWZTMKBR6ELts6aWyb-eKvk',
  authDomain: 'ricecode-meals.firebaseapp.com',
  projectId: 'ricecode-meals',
  storageBucket: 'ricecode-meals.appspot.com',
  messagingSenderId: '295408759994',
  appId: '1:295408759994:web:97aa133d5069faa4737e83'
}

const app = initializeApp(firebaseConfig)
const db = getFirestore(app)

const getUser = async (email) => {
  const userSnapshot = await getDoc(doc(db, 'users', email))
  if (userSnapshot.exists()) {
    return userSnapshot.data()
  } else {
    const user = { email: email, products: [] }
    await getDoc(doc(db, email, user))
    return user
  }
}

const getAllProducts = async () => {
  const productsSnapshot = await getDoc(doc(db, 'products', 'products'))
  if (productsSnapshot.exists()) {
    return productsSnapshot.data()
  }
  return []
}

const getAllReceipts = async () => {
  const receiptsSnapshot = await getDoc(doc(db, 'receipts', 'receipts'))
  if (receiptsSnapshot.exists()) {
    return receiptsSnapshot.data()
  }
  return []
}

const updateUser = async (user) => {
  const userRef = doc(db, 'users', user.email)
  await setDoc(userRef, {
    email: user.email,
    products: user.products
  })
}

export { getUser, updateUser, getAllReceipts, getAllProducts }

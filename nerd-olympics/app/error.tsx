'use client'
import React from 'react';
import Link from 'next/link';

const ErrorPage = () => {
  return (
    <div style={{textAlign: 'center', marginTop: '100px'}}>
      <h1>Oops! Something went wrong</h1>
      <p>Try refreshing the page or go back to the home page</p>
      <button onClick={() => window.location.reload()}>Refresh</button>
      <Link href="/">
        <a>Home</a>
      </Link>
    </div>
  );
};

export default ErrorPage;
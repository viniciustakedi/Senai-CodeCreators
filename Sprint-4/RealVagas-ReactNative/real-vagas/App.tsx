import * as React from 'react';
import { StyleSheet } from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import ScreensMenu from './src/components/ScreenMenu';

export default function App() {
  return (
      <NavigationContainer>
        <ScreensMenu />
      </NavigationContainer>
  );
}


const styles = StyleSheet.create({
  option: {
    fontSize: 20,
  },
})
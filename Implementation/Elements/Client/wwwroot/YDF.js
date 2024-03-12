function putFocusOnElement(element) {
  element.focus();
}

function triggerLeftClickEvent(element) {
  element.click();
}

// window.TestClass = class TestClass {
//  
//   static test(blackbox) {
//     console.log("Sample method")
//     console.log(blackbox);
//   }
//  
// }

/* @param { Element } */
function getDOM_ElementOffsetCoordinates(targetElement) {
  return {
    left: targetElement.offsetLeft,
    top: targetElement.offsetTop
  };
}